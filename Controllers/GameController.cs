using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TabletopStore.Data.Services;
using TabletopStore.Models.Games;

namespace TabletopStore.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        public GameController(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public IActionResult Index(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Categories");
            }

            var selectedGame = _gameRepository.Games.FirstOrDefault(g => g.GameId == id);
            if (selectedGame != null)
            {
                return View(selectedGame);
            }
            else
            {
                return RedirectToAction("Index", "Categories");
            }
        }
    }
}