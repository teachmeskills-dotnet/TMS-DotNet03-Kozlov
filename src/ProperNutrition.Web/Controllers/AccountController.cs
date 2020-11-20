using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Common.Interfaces;
using ProperNutrition.DAL.Entities;
using ProperNutrition.Web.ViewModels;
using System;
using System.Threading.Tasks;

namespace ProperNutrition.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountManager _accountManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IAccountManager accountManager, SignInManager<ApplicationUser> signInManager)
        {
            _accountManager = accountManager ?? throw new ArgumentNullException(nameof(accountManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Applicationusername,
                };

                var result = await _accountManager.SignUpAsync(model.Email, model.Applicationusername, model.Password);


                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Home");
                }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn(string returnUrl = null)
        {
            var signInViewModel = new SignInViewModels
            {
                ReturnUrl = returnUrl
            };
            return View(signInViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInViewModels model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                        return RedirectToAction("Index", "Home");
                }
                    ModelState.AddModelError(string.Empty, "Incorrect login and (or) password");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
