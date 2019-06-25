using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.Services;

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
