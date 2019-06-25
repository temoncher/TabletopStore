using System.Collections.Generic;
using TabletopStore.Models.Games;

namespace TabletopStore.Data.ViewModels
{
    public class GameListViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public string CurrentCategory { get; set; }
    }
}
