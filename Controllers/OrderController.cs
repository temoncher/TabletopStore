using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.Services;
using TabletopStore.Data.ViewModels;
using TabletopStore.Models;

namespace TabletopStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart )
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult List(IEnumerable<Order> orders)
        {
            OrderListViewModel viewModel = new OrderListViewModel();
            viewModel.Orders = orders;

            return View(viewModel);
        }

        public IActionResult Checkout()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.Items = items;

            if(_shoppingCart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty :( Go get some games first!");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                order.Customer.AddOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order! Your games will be at your place shortly! :)";
            return View();
        }
    }
}