using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Web.Common.Navigation
{
    public class MenuHelper
    {
        public static MenuItem Menu;

        public static void LoadMenu(IHostingEnvironment env)
        {
            var stream = new FileStream(env.ContentRootPath + "/Common/Navigation/MenuStructure.json", FileMode.Open);
            var menuJson = new StreamReader(stream).ReadToEnd();
            Menu = JsonConvert.DeserializeObject<MenuItem>(menuJson);
        }

        public static bool UserHasProduct(string menuProducts, List<string> userProducts)
        {
            var menuproductslist = menuProducts.Split(' ');
            return menuproductslist.Intersect(userProducts).Count() != 0;
        }
    }


    public class MenuItem
    {
        public string Name { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public string Access { get; set; }
        public string Product { get; set; }
        public List<MenuItem> Items { get; set; }
    }
    
}
