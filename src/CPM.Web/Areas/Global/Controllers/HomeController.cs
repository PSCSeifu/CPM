

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CPM.Web.Common.Navigation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CPM.Web.Areas.Global.Controllers
{
   
    [Area("Global")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }

            return View();

            //if(User.FindFirst("usertype").Value == "Customer")
            //{
            //    return View();
            //}
            //return RedirectToAction("Index", "Account", new { Area = "Global" });

        }

        public IActionResult Error()
        {
            HttpContext.Authentication.SignOutAsync("cpmAuthCookies");
            return View();
        }
    }
}