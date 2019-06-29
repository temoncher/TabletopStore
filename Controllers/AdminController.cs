using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.ViewModels;
using TabletopStore.Models.Roles;

namespace TabletopStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public ViewResult Index() => View();

        public ViewResult Users()
        {
            AdminUsersViewModel viewModel = new AdminUsersViewModel()
            {
                Users = _userManager.Users.ToList()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Profile(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            AdminProfileViewModel viewModel = new AdminProfileViewModel()
            {
                User = user,
                UserId = id,
                IsAdmin = false,
                IsSalesperson = false
            };
            var userRoles = await _userManager.GetRolesAsync(user);

            if (userRoles.Contains("admin"))
            {
                viewModel.IsAdmin = true;
            }

            if (userRoles.Contains("salesperson"))
            {
                viewModel.IsSalesperson = true;
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SwitchSalesperson(AdminProfileViewModel viewModel)
        {
            User user = await _userManager.FindByIdAsync(viewModel.UserId);
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            var isPresent = false;
            foreach (var role in roles)
            {
                if (role.Name == "salesperson")
                {
                    isPresent = true;
                }
            }
            if (!isPresent)
            {
                await _roleManager.CreateAsync(new IdentityRole("salesperson"));
            }
            if (viewModel.IsSalesperson)
            {
                await _userManager.RemoveFromRolesAsync(user, new List<string>() { "salesperson" });
            }
            else
            {
                await _userManager.AddToRolesAsync(user, new List<string>() { "salesperson" });
            }

            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> SwitchAdmin(AdminProfileViewModel viewModel)
        {
            User user = await _userManager.FindByIdAsync(viewModel.UserId);
            List<IdentityRole> roles = _roleManager.Roles.ToList();
            var isPresent = false;
            foreach (var role in roles)
            {
                if (role.Name == "admin")
                {
                    isPresent = true;
                }
            }
            if (!isPresent)
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (viewModel.IsAdmin)
            {
                await _userManager.RemoveFromRolesAsync(user, new List<string>() { "admin" });
            }
            else
            {
                await _userManager.AddToRolesAsync(user, new List<string>() { "admin" });
            }
            return RedirectToAction("Users");
        }
    }
}