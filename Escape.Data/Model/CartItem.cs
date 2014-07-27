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
