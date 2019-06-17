using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabletopStore.Models
{
    public class Game
    {
        //EF id for Game class
        public int GameId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int PrefferedAge { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayers { get; set; }
        public int Time { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public int AmountInStock { get; set; }
        public bool IsHit { get; set; }

        //Properties down below link Games and Categories together (will be used by EF by default to create relatations in the database)
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
