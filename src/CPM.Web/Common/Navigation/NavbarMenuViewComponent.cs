using CPM.Web.Common.Session;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace CPM.Web.Common.Navigation
{
    public class NavbarMenuViewComponent : ViewComponent
    {
        private ISessionHelper _sessionHelper;

        public NavbarMenuViewComponent(ISessionHelper sessionHelper)
        {
            _sessionHelper = sessionHelper;
        }

        public IViewComponentResult Invoke()
        {
            var menu = MenuHelper.Menu.Items;

            return View(menu);
        }

        public IViewComponentResult InvokeAsync()
        {
            var menu = MenuHelper.Menu.Items;

            return View(menu);
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    //var menu = MenuHelper.Menu.Items;

        //    List<MenuItem> menu = new List<MenuItem>();

        //    menu.Add(new MenuItem());
        //    menu.Add(new MenuItem());
        //    menu.Add(new MenuItem());


        //    //User based logic
        //    // ViewBag.Currency = "CPM Platform";
        //    //menu = menu.Select(m => m).ToList();

        //    return  View("Default",menu);
        //}
    }
}
