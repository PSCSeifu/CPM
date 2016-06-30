using CPM.Web.Common.Session;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace CPM.Web.Common.Navigation
{
    public class NavbarMenuViewComponent : ViewComponent
    {
        private ISessionHelper _sessionHelper;

        public NavbarMenuViewComponent(ISessionHelper sessionHelper)
        {
            _sessionHelper = sessionHelper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menu = MenuHelper.Menu.Items;

            //User based logic
            ViewBag.Currency = "CPM Platform";
            menu = menu.Select(m => m).ToList();

            return  View(menu);
        }
    }
}
