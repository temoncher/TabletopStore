using System.Collections.Generic;

namespace TabletopStore.Models
{
    public class Category
    {
        //EF ID for Category class
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //One to Many relationship between Category and Games
        public List<Game> List { get; set; }

    }
}
