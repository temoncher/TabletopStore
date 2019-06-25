using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TabletopStore.Data;
using TabletopStore.Models.Games;

namespace TabletopStore.Models.ShoppingCart
{
    public class ShoppingCart
    {
        //Using dependency injection with DB context
        private readonly StoreDBContext _context;
        private ShoppingCart(StoreDBContext context)
        {
            _context = context;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> Items { get; set; }


        public static ShoppingCart GetCart(IServiceProvider services)
        {
            //To proide some space for shopping cart data we use sessions
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<StoreDBContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        //Adding item to shopping cart
        public void AddToCart(Game game, int amount)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Game.GameId == game.GameId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Game = game,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

        //Removing item
        public int RemoveFromCart(Game game)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Game.GameId == game.GameId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();

            return localAmount;
        }

        //Remove all instances of specific game
        public void RemoveAllFromCart(int gameId)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(s => s.Game.GameId == gameId && s.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.Remove(shoppingCartItem);

            _context.SaveChanges();
        }

        //Using EF extension methods to retrieve all items from cart into List
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return Items ?? (Items = _context.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Game)
                .ToList()
                );
        }

        //Clearing entire cart
        public void ClearCart()
        {
            var cartItems = _context
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        //Counting total cost of all the items in cart
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Game.Price * c.Amount)
                .Sum();

            return total;
        }
    }
}
