using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopStore.Models
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
