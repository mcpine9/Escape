using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data
{
    class CartItem
    {
        public int CartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public decimal Discount { get; set; }

        public virtual ShoppinCart ShoppingCart { get; set; }
        public virtual MainProductInfo MainProductInfo { get; set; }
    }
}
