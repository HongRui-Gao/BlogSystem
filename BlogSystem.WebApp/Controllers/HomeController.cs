using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.WebApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 这个是我们博客系统的首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}