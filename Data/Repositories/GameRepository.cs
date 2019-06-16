using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;
using TabletopStore.Services;

namespace TabletopStore.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
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
