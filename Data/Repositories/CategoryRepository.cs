using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;
using TabletopStore.Services;

namespace TabletopStore.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDBContext _context;

        public CategoryRepository(StoreDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories;
    }
}
