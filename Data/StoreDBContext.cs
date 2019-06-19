﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopStore.Models
{
    public class StoreDBContext : IdentityDbContext<IdentityUser>
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
