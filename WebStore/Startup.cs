using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Middleware;
using WebStore.Infrastructure.Services;

namespace WebStore
{
    public record Startup(IConfiguration Configuration)
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEmployeesData, InMemoryEmployeesData>();
            services.AddTransient<IProductData, InMemoryProductData>();

            services
                .AddControllersWithViews()
                .AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseWelcomePage("/welcome");

            app.UseMiddleware<TestMiddleware>();
            app.Map("/hello", context => context.Run(async request => await request.Response.WriteAsync("Hello!")));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}