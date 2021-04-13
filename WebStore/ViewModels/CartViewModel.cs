using System.Collections.Generic;
using System.Linq;

namespace WebStore.ViewModels
{

    public class CartViewModel
    {
        public IEnumerable<(ProductViewModel Product, int Qty)> Items { get; set; }

        public int ItemsCount => Items?.Sum(i => i.Qty) ?? 0;

        public decimal TotalPrice => Items?.Sum(i => i.Product.Price * i.Qty) ?? 0m;
    }

}