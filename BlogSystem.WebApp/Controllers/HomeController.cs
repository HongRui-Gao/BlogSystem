using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Models.Category;
namespace BlogSystem.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryBll _categorySvc;

        public HomeController(ICategoryBll categorySvc)
        {
            _categorySvc = categorySvc;
        }

        /// <summary>
        /// 这个是我们博客系统的首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            #region 文章类别的绑定

            var data = await _categorySvc.GetDataByTop4();
            var categoryList = data.Select(c => new CateogoryListViewModel {
                Title = c.Title,
                Details = c.Details
            }).ToList();

            ViewBag.CategoryList = categoryList;


            #endregion



            return View();
        }
    }
}