using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;

namespace TabletopStore.Services
{
    /// <summary>
    /// We need this interface to set up custom service, that will help us with mock database before we get to EntityFramework.
    /// After we create our repositories we can simply switch our classes in Startup.cs from Mock to Repository ones.
    /// Mock categories can be found in /data/mocks
    /// </summary>
    public interface IGameRepository
    {
        //Both properties have no "set" method, cause we only need them to fill our database. No other editing allowed.
        IEnumerable<Game> Games { get; }
        //List of hits to display them on front page
        IEnumerable<Game> Hits { get; }
        Game GetGameById(int gameId);

    }
}
