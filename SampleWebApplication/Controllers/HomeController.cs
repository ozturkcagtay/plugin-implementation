using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleWebApplication.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [OutputCache(Duration = 10)]
        public PartialViewResult Menu()
        {
            #region Plugin Menu Items
            var menuItems = new List<Models.MenuItem>();
            var plugins = PluginBusiness.Instance.ListPlugins().ToList();

            plugins.ForEach(e=> {
                menuItems.Add(new Models.MenuItem(e.MenuTitle,e.ControllerName,e.ActionName));
            });
            #endregion


            #region Other Menu Items
            menuItems.Add(new Models.MenuItem("Home","Home","Index"));
            menuItems.Add(new Models.MenuItem("About", "Home", "About"));
            menuItems.Add(new Models.MenuItem("Contact", "Home", "Contact"));
            
            #endregion

            return PartialView(menuItems);
        }
    }
}