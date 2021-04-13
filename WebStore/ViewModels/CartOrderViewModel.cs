using System.Collections.Generic;
using System.Linq;

namespace WebStore.ViewModels
{

    public class CartOrderViewModel
    {
        public CartViewModel Cart { get; set; }

        public OrderViewModel Order { get; set; } = new();
    }

}