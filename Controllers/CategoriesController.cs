using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.Services;
using TabletopStore.Data.ViewModels;
using TabletopStore.Models.Games;

namespace TabletopStore.Controllers
{
    public class CategoriesController : Controller
    {
        //Using Dependency Injection to get instances of repositories
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;

        public CategoriesController(ICategoryRepository categoryRepo, IGameRepository gameRepo)
        {
            _categoryRepository = categoryRepo;
            _gameRepository = gameRepo;
        }

        //
        public ViewResult Index(string category)
        {
            var _category = category;
            IEnumerable<Game> games = _gameRepository.Games
                .Where(g => string.Equals(g.Category.Name, category, StringComparison.OrdinalIgnoreCase))
                .OrderBy(g => g.GameId);

            if (string.IsNullOrEmpty(category))
            {
                games = _gameRepository.Games.OrderBy(g => g.GameId);
                category = "All games";
            }
            else
            {
                if (!games.Any())
                {
                    category = "No games in category, or category not found";
                }
                else
                {
                    category = games.FirstOrDefault().Category.Name;
                }
            }

            GameListViewModel viewModel = new GameListViewModel
            {
                Games = games,
                CurrentCategory = category
            };

            return View(viewModel);
        }
    }
}