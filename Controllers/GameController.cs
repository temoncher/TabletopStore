using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Services;
using TabletopStore.Data.ViewModels;

namespace TabletopStore.Controllers
{
    public class GameController : Controller
    {
        //Using Dependecy Injection to get instances of repositories
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;

        public GameController(ICategoryRepository categoryRepo, IGameRepository gameRepo)
        {
            _categoryRepository = categoryRepo;
            _gameRepository = gameRepo;
        }

        //
        public ViewResult List()
        {
            GameListViewModel viewModel = new GameListViewModel();
            viewModel.Games = _gameRepository.Games;
            viewModel.CurrentCategory = "GameCategory";

            return View(viewModel);
        }
    }
}