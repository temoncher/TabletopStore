using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TabletopStore.Data.Services;
using TabletopStore.Models.Games;

namespace TabletopStore.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        //Injecting DB context so we can interact with the database
        private readonly StoreDBContext _context;
        public GameRepository(StoreDBContext context)
        {
            _context = context;
        }        
        public IEnumerable<Game> Games => _context.Games.Include(c => c.Category);

        public IEnumerable<Game> Hits => _context.Games.Where(p => p.IsHit).Include(c => c.Category);

        public Game GetGameById(int gameId)
        {
           return _context.Games.FirstOrDefault(p => p.GameId == gameId);
        }
    }
}
