using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.SystemMenu;
using PagedList;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    public class SystemMenuManagerController : Controller
    {
        private ISystemMenuBll _bll;

        public SystemMenuManagerController(ISystemMenuBll bll)
        {
            _bll = bll;
        }

        public async Task<ActionResult> List(string Seach="",int page = 1)
        {
            var data = await _bll.GetSystemMenuListByTitle(Seach);
            var list = new List<SystemMenuListViewModel>();

            foreach (var item in data)
            {
                SystemMenuListViewModel smlvm = new SystemMenuListViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Link = item.Link,
                    Icon = item.Icon,
                    ParentTitle = await GetParentTitle(item.ParentId),
                    UpdateTime = item.UpdateTime
                };
                list.Add(smlvm);
            }

            IPagedList<SystemMenuListViewModel> pages = list.ToPagedList(page, PageConfig.GetPageSize());
            ViewBag.Search = Seach;
            return View(pages);
        }



        /// <summary>
        /// 根据父级菜单id进行查询得到对应的父级菜单名称
        /// </summary>
        /// <param name="pid">父级菜单id</param>
        /// <returns>父级菜单名称</returns>
        public async Task<string> GetParentTitle(Guid pid)
        {
            if (pid == Guid.Empty)
                return "一级菜单";
            var data = await _bll.GetSystemMenu(pid);
            return data.Title;
        }
    }
}