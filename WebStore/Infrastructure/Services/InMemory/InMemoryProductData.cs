﻿using System.Collections.Generic;
using System.Linq;
using WebStore.Data;
using WebStore.Domain;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;


namespace WebStore.Infrastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Brand> GetBrands() => TestData.Brands;


        public IEnumerable<Section> GetSections() => TestData.Sections;
        public IEnumerable<Product> GetProducts(ProductFilter Filter)
        {
            var query = TestData.Products;

            if (Filter?.SectionId is { } section_id)
                query = query.Where(product => product.SectionId == section_id);

            if (Filter?.BrandId is { } brand_id)
                query = query.Where(product => product.BrandId == brand_id);

            return query;


        }

        public Product GetProductsById(int id)
        {
            return TestData.Products.Where(product => product.Id == id).FirstOrDefault();
        }
       



    }
}
