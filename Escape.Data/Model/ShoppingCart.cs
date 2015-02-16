using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("ShoppingCart")]
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int ShoppingCartId { get; set; }

        public DateTime DateCreated { get; set; }

        public string Message { get; set; }

        public int? Customer_CustomerId { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
