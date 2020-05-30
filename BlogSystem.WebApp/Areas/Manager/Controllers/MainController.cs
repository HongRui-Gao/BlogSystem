using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogSystem.WebApp.Filter;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    public class MainController : Controller
    {
        [AdminAuthorize]
        // GET: Manager/Main
        public ActionResult Welcome()
        {
            return View();
        }
    }
}