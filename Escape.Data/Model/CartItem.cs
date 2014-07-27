using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data.Model
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public int ShoppingCartID { get; set; }
        public virtual ShoppingCart ShoppingCart { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
