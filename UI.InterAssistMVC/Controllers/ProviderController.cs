using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.InterAssistMVC;

namespace UI.InterAssistMVC.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult Index()
        {
            ViewBag.Logout = UI.InterAssistMVC.Resource.LAYOUT_MENU_USER_LOGOUT;
            return View();
        }
    }
}