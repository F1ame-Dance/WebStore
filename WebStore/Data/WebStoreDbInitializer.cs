using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL.Context;

namespace WebStore.Data
{
    public class WebStoreDbInitializer
    {
        private readonly WebStoreDB _db;
        private readonly ILogger<WebStoreDbInitializer> _logger;
        public WebStoreDbInitializer(WebStoreDB db, ILogger<WebStoreDbInitializer> logger)
        {
            _db = db;
            _logger = logger;
        } 
       
        public void Initialize()
        {
            var db = _db.Database;

            if(db.GetPendingMigrations().Any())
            {
                _logger.LogInformation("Начало миграции");
                db.Migrate();
                _logger.LogInformation("Конец миграции");

            }
            else
            {
                _logger.LogInformation("Актуальная версия");
            }

            try
            {
                InitializeProducts();
            }
            catch (Exception)
            {

                _logger.LogError("Ошибка при выполнении инициализации");
                    throw;
            }
        }

        private void InitializeProducts()
        {

            if(_db.Products.Any())
            {
                _logger.LogInformation("Инициализация товаров не требуется");
                return;
            }
           

            _logger.LogInformation("Инициализация товаров");

            _logger.LogInformation("Добавление секций");
            using (_db.Database.BeginTransaction())
            {
                _db.Sections.AddRange(TestData.Sections);
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] ON");

                _db.SaveChanges();

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Sections] OFF");

                _db.Database.CommitTransaction();
            }

            _logger.LogInformation("Добавление брендов");

            using (_db.Database.BeginTransaction())
            {
                _db.Brands.AddRange(TestData.Brands);
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] ON");

                _db.SaveChanges();

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Brands] OFF");

                _db.Database.CommitTransaction();
            }

            _logger.LogInformation("Добавление товаров");

            using (_db.Database.BeginTransaction())
            {
                _db.Products.AddRange(TestData.Products);
                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");

                _db.SaveChanges();

                _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");

                _db.Database.CommitTransaction();
            }
        }
    }
}
