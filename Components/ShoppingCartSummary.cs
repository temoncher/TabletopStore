﻿using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.ViewModels;
using TabletopStore.Models.ShoppingCart;

namespace TabletopStore.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            //var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem(), new ShoppingCartItem() };
            _shoppingCart.Items = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            return View(shoppingCartViewModel);
        }
    }
}
