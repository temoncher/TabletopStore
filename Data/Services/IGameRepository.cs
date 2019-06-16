using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;

namespace TabletopStore.Services
{
    public interface IGameRepository
    {
        IEnumerable<Game> Games { get; }
        IEnumerable<Game> Hits { get; }

        Game GetGameById(int gameId);

    }
}
