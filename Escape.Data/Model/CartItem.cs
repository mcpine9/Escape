using System.ComponentModel.DataAnnotations.Schema;

namespace Escape.Data.Model
{
    [Table("CartItem")]
    public partial class CartItem
    {
        public int CartItemId { get; set; }

        public int ShoppingCartID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
    }
}
