﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.Services;
using TabletopStore.Data.ViewModels;
using TabletopStore.Models.ShoppingCart;

namespace TabletopStore.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartController(IGameRepository gameRepository, ShoppingCart shoppingCart)
        {
            _gameRepository = gameRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            if (_shoppingCart != null) {
                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.Items = items;

                var shoppingCartVM = new ShoppingCartViewModel
                {
                    ShoppingCart = _shoppingCart,
                    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
                };
                return View(shoppingCartVM);
            }
            else
            {
                var shoppingCartVM = new ShoppingCartViewModel
                {
                    ShoppingCart = _shoppingCart,
                    ShoppingCartTotal = 0
                };
                return View(shoppingCartVM);
            }
        }

        public RedirectToActionResult AddToShoppingCart(int id)
        {
            var selectedGame = _gameRepository.Games.FirstOrDefault(p => p.GameId == id);
            if (selectedGame != null)
            {
                _shoppingCart.AddToCart(selectedGame, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var selectedGame = _gameRepository.Games.FirstOrDefault(p => p.GameId == id);
            if (selectedGame != null)
            {
                _shoppingCart.RemoveFromCart(selectedGame);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult ClearCart(int gameId)
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveAllFromShoppingCart(int id)
        {
            _shoppingCart.RemoveAllFromCart(id);
            return RedirectToAction("Index");
        }
    }
}