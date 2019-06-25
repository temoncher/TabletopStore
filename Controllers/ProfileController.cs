using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TabletopStore.Data.ViewModels;
using TabletopStore.Models.Roles;

namespace TabletopStore.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        //private User _user;

        public ProfileController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Edit()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.FindByIdAsync(userId).Result;

            if (_user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { UserName = _user.UserName, Email = _user.Email };
            return View(model);
        }
        public ViewResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.FindByIdAsync(userId).Result;

            return View(_user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.FindByIdAsync(userId).Result;

            if (ModelState.IsValid)
            {
                if (_user != null)
                {
                    _user.Email = model.Email;
                    _user.UserName = model.UserName;

                    var result = await _userManager.UpdateAsync(_user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.FindByIdAsync(userId).Result;

            if (_user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(_user);
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ChangePassword()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.FindByIdAsync(userId).Result;

            if (_user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Email = _user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var _user = _userManager.FindByIdAsync(userId).Result;

            if (ModelState.IsValid)
            {
                if (_user != null)
                {
                    IdentityResult result =
                        await _userManager.ChangePasswordAsync(_user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                }
            }
            return View(model);
        }
    }
}