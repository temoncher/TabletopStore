using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TabletopStore.Models.Games;
using TabletopStore.Models.Orders;
using TabletopStore.Models.Roles;
using TabletopStore.Models.ShoppingCart;

namespace TabletopStore.Data
{
    public class StoreDBContext : IdentityDbContext<User>
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }

        //db of all shopping cart items
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        //db for Orders and order details for each order

        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
