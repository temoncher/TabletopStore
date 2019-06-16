using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Models;
using TabletopStore.Services;

namespace TabletopStore.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category(){ Name="Logic", Description="Игра, которая проверяет на прочность твое логическое мышление."},
                    new Category(){ Name="Reaction", Description="Игра для тех, кто быстрее ветра! А также для тех, кто не боится бросить вызвов своим друзьям!"},
                };
            }
        }
    }
}
