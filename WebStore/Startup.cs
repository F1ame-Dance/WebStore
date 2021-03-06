﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebStore.DAL.Context;
using WebStore.Data;
using WebStore.Domain.Identity;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Middleware;
using WebStore.Infrastructure.Services;
using WebStore.Infrastructure.Services.InCookies;
using WebStore.Infrastructure.Services.InSQL;

namespace WebStore
{
    public record Startup(IConfiguration Configuration)
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection_string_name = Configuration["ConnectionString"];

            switch(connection_string_name)
            {
                case "SqlServer":
                    services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(Configuration.GetConnectionString(connection_string_name)));
                    break;
                case "Sqlite":
                    services.AddDbContext<WebStoreDB>(opt => opt.UseSqlite(Configuration.GetConnectionString(connection_string_name), o => o.MigrationsAssembly("WebStore.DAL.Sqlite")));
                    break;
                default: throw new InvalidOperationException($"Подключение {connection_string_name} не поддерживается");

            }

            services.AddTransient<WebStoreDbInitializer>();

            services.AddIdentity<User, Role>(/*opt => { }*/)
               .AddEntityFrameworkStores<WebStoreDB>()
               .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
#if DEBUG
                opt.Password.RequiredLength = 3;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredUniqueChars = 3;
#endif
                opt.User.RequireUniqueEmail = false;
                opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_-";

                opt.Lockout.AllowedForNewUsers = false;
                opt.Lockout.MaxFailedAccessAttempts = 10;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "WebStore.GB";
                opt.Cookie.HttpOnly = true;
                opt.ExpireTimeSpan = TimeSpan.FromDays(10);

                opt.LoginPath = "/Account/Login";
                opt.LogoutPath = "/Account/Logout";
                opt.AccessDeniedPath = "/Account/AccessDenied";

                opt.SlidingExpiration = true;
            });

            services.AddTransient<IEmployeesData, InMemoryEmployeesData>();
            //services.AddTransient<IProductData, InMemoryProductData>();
            services.AddTransient<IProductData, SqlProductData>();
            services.AddTransient<IOrderService, SqlOrderService>();
            services.AddTransient<ICartService, InCookiesCartService>();

            services
               .AddControllersWithViews()
               .AddRazorRuntimeCompilation();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebStoreDbInitializer db)
        {
            db.Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseWelcomePage("/welcome");

            app.UseMiddleware<TestMiddleware>();

            app.MapWhen(
                context => context.Request.Query.ContainsKey("id") && context.Request.Query["id"] == "5",
                context => context.Run(async request => await request.Response.WriteAsync("Hello with id == 5!"))
            );
            app.Map("/hello", context => context.Run(async request => await request.Response.WriteAsync("Hello!!!")));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   "areas",
                   "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

