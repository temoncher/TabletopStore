using TabletopStore.Models.Games;

namespace TabletopStore.Models.ShoppingCart
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Game Game { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
