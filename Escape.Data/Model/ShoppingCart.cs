using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escape.Data.Model
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public DateTime DateCreated { get; set; }
        public IQueryable<int> CustomerId { get; set; }
        public string Message { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } 
    }
}
