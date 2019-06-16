using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;

namespace TabletopStore.Data.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Game> HitGames { get; set; }
    }
}
