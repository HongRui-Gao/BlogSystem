using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.Roles;
using log4net;
using log4net.Core;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    public class RolesManagerController : Controller
    {
        private IRolesBll _rolesBll;

        public RolesManagerController(IRolesBll rolesBll)
        {
            _rolesBll = rolesBll;
           
        }
        //1. 每页展示多少条
        //2. 一共能分多少页
        public async Task<ActionResult> List(string Search="",int page = 1)
        {
            //注册日志
            ILog log = LogManager.GetLogger(typeof(RolesManagerController));
            //(1) 得到我们数据的总条数
            var count = await _rolesBll.GetRolesCountAsync(Search);
            //(2) 设置总页数
            var total = PageConfig.GetTotalPage(count);
            //(3) 设置每页要展示条数
            var pageSize = PageConfig.GetPageSize();

            var data = await _rolesBll.GetRolesListByPageAsync(pageSize, page, Search, false);
            List<RolesListViewModel> list = new List<RolesListViewModel>();

            foreach (var item in data)
            {
                RolesListViewModel rlvm = new RolesListViewModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    UpdateTime = item.UpdateTime
                };
                list.Add(rlvm);
            }

            ViewBag.Search = Search;
            ViewBag.Total = total;
            ViewBag.PageIndex = page;

            return View(list);
        }
    }
}