﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Components
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public BrandsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke() => View(GetBrands());

        private IEnumerable<BrandsViewModel> GetBrands() =>
            _ProductData.GetBrands()
               .OrderBy(brand => brand.Order)
               .Select(brand => new BrandsViewModel
               {
                   Id = brand.Id,
                   Name = brand.Name,
                   ProductCount = brand.Products.Count()
               });
    }
}