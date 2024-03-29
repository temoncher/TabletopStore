﻿using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.Services;
using TabletopStore.Data.ViewModels;

namespace TabletopStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameRepository _gameRepository;
        public HomeController(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
        }
        public ViewResult Index()
        {
            var homeVM = new HomeViewModel
            {
                Games = _gameRepository.Games,
                HitGames = _gameRepository.Hits,
            };
            return View(homeVM);
        }

    }
}
