using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;
using TabletopStore.Services;

namespace TabletopStore.Data.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<Game> HitGames { get; set; }
    }
}
