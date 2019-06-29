using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.Services;
using TabletopStore.Data.ViewModels;
using TabletopStore.Models.Orders;
using TabletopStore.Models.Roles;
using TabletopStore.Models.ShoppingCart;

namespace TabletopStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly UserManager<User> _userManager;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, UserManager<User> userManager)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _userManager = userManager;
        }

        public ViewResult Checkout() => View();

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.Items = items;

            if(_shoppingCart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty :( Go get some games first!");
                ViewBag.CheckoutError = "Your cart is empty :( Go get some games first!";
            }

            if (ModelState.IsValid)
            {
                order.Customer = await _userManager.FindByEmailAsync(order.Email);
                if (order.Customer == null)
                {
                    ModelState.AddModelError("", "E-mail not found");
                    ViewBag.CheckoutError = "E-mail not found";
                }
                else
                {
                    _orderRepository.CreateOrder(order);
                    order.Customer.Orders.Add(order);
                    //order.Customer.AddOrder(order);
                    _shoppingCart.ClearCart();
                    return RedirectToAction("CheckoutComplete");
                }
            }
            return View(order);
        }

        public ViewResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for the order! Games will be at your place shortly! :)";
            return View();
        }
    }
}