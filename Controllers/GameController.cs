using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Services;
using TabletopStore.Data.ViewModels;
using TabletopStore.Models;

namespace TabletopStore.Controllers
{
    public class GamesController : Controller
    {
        //Using Dependecy Injection to get instances of repositories
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;

        public GamesController(ICategoryRepository categoryRepo, IGameRepository gameRepo)
        {
            _categoryRepository = categoryRepo;
            _gameRepository = gameRepo;
        }

        //
        public ViewResult List(string category)
        {
            var _category = category;
            IEnumerable<Game> games = _gameRepository.Games.Where(g => string.Equals(g.Category.Name, category, StringComparison.OrdinalIgnoreCase)).OrderBy(g => g.GameId);

            if (string.IsNullOrEmpty(category))
            {
                games = _gameRepository.Games.OrderBy(g => g.GameId);
                category = "All games";
            }
            else
            {
                if (games.Count() == 0)
                {
                    category = "No games in category, or category not found";
                }
                else
                {
                    category = games.FirstOrDefault().Category.Name;
                }
            }

            GameListViewModel viewModel = new GameListViewModel();
            viewModel.Games = games;
            viewModel.CurrentCategory = category;

            return View(viewModel);
        }
    }
}