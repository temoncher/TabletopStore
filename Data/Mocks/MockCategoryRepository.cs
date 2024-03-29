﻿using System.Collections.Generic;
using TabletopStore.Data.Services;
using TabletopStore.Models.Games;

namespace TabletopStore.Data.Mocks
{
    /// <summary>
    /// Was created for testing purposes only
    /// </summary>
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
