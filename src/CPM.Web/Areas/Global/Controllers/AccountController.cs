
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
using CPM.Web.Common.Session;
using CPM.Business.Global.Account;
using CpmLib.Business.Core.Service;
using CPM.Web.Common.Account;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Claims;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Global
{
    [Area("Global")]
    [Authorize]
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private ISessionHelper _sessionHelper;
        private IHasher _hasher;
 

        public AccountController(ISessionHelper sessionHelper, IAccountService accountService,IHasher hasher)
        {
            _sessionHelper = sessionHelper;
            _accountService = accountService;
            _hasher = hasher;
         
        }


        #region _Register_

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public  IActionResult Register(RegisterVM model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //Set user ceredentails
                var cpmUser = new CPMUserBM { Username = model.Username, Email = model.Email };

                //Create the user
                //var result = await _userManager.CreateAsync(cpmUser, model.Password);
                var result =  _accountService.CreateUser(cpmUser);
                               

                //SignIn
                if (result.Result == ProcessResultEnum.Success)
                {
                    //Login
                    LoginVM vm = new LoginVM();
                    vm.Username = model.Username;
                    vm.Password = model.Password;
                    vm.ReturnUrl = returnUrl;
                    vm.RememberMe = model.RememberMe;
                    Login(vm, vm.ReturnUrl).Wait();

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    ModelState.AddModelError(result.Error.Message, result.ErrorDescription);                    
                }
            }

            return View();
        }

        #endregion


        #region _Login_
        
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM login, string returnUrl)
        {
            if (!_accountService.UserExists(login.Username).Item)
            {
                //_logService.LogLoginFailed(string.Format("{0} | {1}", Request.Host.Value, login.Username));
                ModelState.AddModelError("Password", "Username or password incorrect");
            }
            else if (ModelState.IsValid)
            {
                var user = _accountService.FinduserByUsername(login.Username).Item;

                var result = _hasher.VerifyHashedPassword(user, user.PasswordHash, login.Password);

                switch (result)
                {
                    case PasswordVerificationResult.SuccessRehashNeeded:
                    case PasswordVerificationResult.Success:
                        SetSessionVariables(user);

                        //_logService.LogLoginSuccessful(user.Id, string.Format("{0} | {1}", Request.Host, login.Username));
                        
                        var claims = new List<System.Security.Claims.Claim>
                        {
                            new System.Security.Claims.Claim("username", user.Username),
                            new System.Security.Claims.Claim("email", user.Email),
                            new System.Security.Claims.Claim("usertype", user.WebUserType.ToString()),
                            new System.Security.Claims.Claim("eSlip", user.cpmAnalytics.ToString()),
                            new System.Security.Claims.Claim("eInput", user.cpmAutoBargain.ToString()),
                            new System.Security.Claims.Claim("eLink", user.cpmModerate.ToString()),
                            new System.Security.Claims.Claim("eHR", user.cpmNews.ToString()),
                            new System.Security.Claims.Claim("SelfService", user.cpmForum.ToString()),
                            new System.Security.Claims.Claim("SelfService", user.cpmEscrow.ToString())
                        };

                        var identity = new ClaimsIdentity(claims, "local", "username", "usertype");
                        await HttpContext.Authentication.SignInAsync("eServicesAuthCookies", new ClaimsPrincipal(identity));

                        if (!user.AgreedOnTerms)
                        {
                            return RedirectToAction("License", new { ReturnUrl = returnUrl });
                        }
                        else
                        {
                            return RedirectToReturnUrl(returnUrl);
                        }
                    case PasswordVerificationResult.Failed:
                    default:
                        //_logService.LogLoginFailed(string.Format("{0} | {1}", Request.Host, login.Username));
                        ModelState.AddModelError("Password", "Username or password incorrect");
                        return View(login);
                }
            }
            return View();
        }

        #endregion


        #region _Logout_
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("cpmAuthCookies");
            return RedirectToAction("Login");
        }
        #endregion

        //[HttpGet]
        //public IActionResult Login(string returnUrl)
        //{
        //    var model = new LoginVM { ReturnUrl = returnUrl };
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginVM model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Attempt aign in
        //        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,false);

        //        //Login OR Redirect
        //        //second check - if there is a url, check the url to prevent phising attacks.
        //        if (result.Succeeded)
        //        {
        //            return Redirect(model.ReturnUrl);
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index","Home");
        //        }
        //    }

        //    ModelState.AddModelError("", "Invalid Login Attempt");
        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();

        //    return RedirectToAction("Index", "Home");
        //}


        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        private void SetSessionVariables(CPMUserBM user)
        {
            _sessionHelper.CPMUser = AutoMapper.Mapper.Map<SessionCPMUserVM>(user);
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
