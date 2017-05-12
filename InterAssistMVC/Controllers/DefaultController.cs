using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterAssistMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            this.AssignTextToView();
            return View();
        }

        private void AssignTextToView()
        {
            ViewBag.Logout = InterAssistMVC.Resource.LAYOUT_MENU_USER_LOGOUT;
            ViewBag.Setings = InterAssistMVC.Resource.LAYOUT_MENU_USER_SETINGS;
            ViewBag.Profile = InterAssistMVC.Resource.LAYOUT_MENU_USER_PROFIL;
            ViewBag.Menu = InterAssistMVC.Models.Menu.GetMenu();
        }
    }
}