using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Models.WebMenu;

namespace BlogSystem.WebApp.Controllers
{
    public class FrontEndLayoutController : Controller
    {
        private IWebMenuBll _wmSvc;
        public FrontEndLayoutController(IWebMenuBll wmSvc)
        {
            _wmSvc = wmSvc;
        }
        [HttpGet]
        public async Task<JsonResult> GetLists()
        {

            var data = await _wmSvc.GetWebMenuList();

            var list = new List<WebMenuListViewModel>();

            for (var i = data.Count - 1; i >= 0; i--) 
            {
                var model = new WebMenuListViewModel 
                {
                    Title = data[i].Title,
                    Link = data[i].Link
                };
                list.Add(model);
            }
            return Json(list,JsonRequestBehavior.AllowGet);
        }
    }
}