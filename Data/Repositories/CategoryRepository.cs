using System.Collections.Generic;
using TabletopStore.Data.Services;
using TabletopStore.Models.Games;

namespace TabletopStore.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        //Injecting DB context so we can interact with the database
        private readonly StoreDBContext _context;

        public CategoryRepository(StoreDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> Categories => _context.Categories;
    }
}
