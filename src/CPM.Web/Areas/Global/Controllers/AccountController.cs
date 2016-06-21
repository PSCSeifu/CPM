
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPM.Web.Areas.Global.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CPM.Web.Areas.Client.Models;
using CPM.Data.Entities;
using CPM.Web.Areas.Global.Controllers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Global
{
    [Area("Global")]
    public class AccountController : Controller
    {
        private readonly SignInManager<CPMUserEntity> _signInManager;
        private readonly UserManager<CPMUserEntity> _userManager;

        public AccountController(UserManager<CPMUserEntity> userManager, SignInManager<CPMUserEntity> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                //Set user ceredentails
                var cpmUser = new CPMUserEntity { UserName = model.Username, Email = model.Email };
               
                //Create the user
                var result = await _userManager.CreateAsync(cpmUser, model.Password);
              
                //Get the role from vm, add to user role
                var userRole = model.WebUserType.ToString();
                await _userManager.AddToRoleAsync(cpmUser, userRole);

                //SignIn
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(cpmUser, isPersistent: false);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginVM { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                //Attempt aign in
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,false);

                //Login OR Redirect
                //second check - if there is a url, check the url to prevent phising attacks.
                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }

            ModelState.AddModelError("", "Invalid Login Attempt");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult RedirectToReturnUrl(string returnUrl)
        {
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("", "");
            }
        }

        //public override UnauthorizedResult Unauthorized()
        //{
        //    return RedirectToAction("Unauthorized", "Home");
        //}


        //public IActionResult Forbidden()
        //{
        //    return RedirectToAction("Unauthorized", "Home");
        //}

    }
}
