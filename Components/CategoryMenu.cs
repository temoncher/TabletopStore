﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TabletopStore.Data.Services;

namespace TabletopStore.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Categories.OrderBy(p => p.Name);
            return View(categories);
        }
    }
}
