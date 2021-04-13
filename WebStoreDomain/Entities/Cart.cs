using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Domain.Entities
{
    public class Cart
    {
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        public int ItemsCount => Items?.Sum( i => i.Qty) ?? 0;
    }
    public class CartItem
    {
        public int ProductId { get; set; }

        public int Qty { get; set; } = 1;
    }
}
