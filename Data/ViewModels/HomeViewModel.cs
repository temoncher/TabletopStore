using System.Collections.Generic;
using TabletopStore.Models;
using TabletopStore.Models.Games;

namespace TabletopStore.Data.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Game> HitGames { get; set; }
    }
}
