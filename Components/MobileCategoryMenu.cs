using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TabletopStore.Services;

namespace TabletopStore.Components
{
    public class MobileCategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public MobileCategoryMenu(ICategoryRepository categoryRepository)
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
