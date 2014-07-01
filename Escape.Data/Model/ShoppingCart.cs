using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data.Model
{
    class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public DateTime DateCreated { get; set; }
        public int CustomerId { get; set; }
        public int Message { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } 
    }
}
