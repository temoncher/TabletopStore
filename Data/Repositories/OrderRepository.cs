using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Data.Services;
using TabletopStore.Models;

namespace TabletopStore.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDBContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(StoreDBContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;                
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            _context.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.Items;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    GameId = item.Game.GameId,
                    OrderId = order.OrderId,
                    Price = item.Game.Price
                };
                _context.OrderDetails.Add(orderDetail);
            }

            _context.SaveChanges();
        }
    }
}
