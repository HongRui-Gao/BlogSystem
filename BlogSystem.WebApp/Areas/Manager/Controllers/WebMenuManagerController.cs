using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.WebMenu;
using BlogSystem.WebApp.Filter;
using PagedList;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class WebMenuManagerController : Controller
    {
        private IWebMenuBll _webMenuSvc;

        public WebMenuManagerController(IWebMenuBll webMenuSvc)
        {
            _webMenuSvc = webMenuSvc;
        }
        MessageBox msg = new MessageBox();


        public async Task<ActionResult> List(string Search ="",int page = 1)
        {
            var data = await _webMenuSvc.GetWebMenuListByTitle(Search);
            var list = new List<WebMenuListViewModel>();

            foreach (var item in data)
            {
                WebMenuListViewModel wlvm = new WebMenuListViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Link = item.Link,
                    Icon = item.Icon,
                    ParentTitle = await GetParentTitle(item.ParentId) ,
                    UpdateTime = item.UpdateTime
                };
                list.Add(wlvm);
            }

            IPagedList<WebMenuListViewModel> pages = list.ToPagedList(page, PageConfig.GetPageSize());
            ViewBag.Search = Search;
            return View(pages);
        }
        /// <summary>
        /// 得到父级菜单的名称
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public async Task<string> GetParentTitle(Guid pid)
        {
            if (pid == Guid.Empty)
                return "一级菜单";
            var data = await _webMenuSvc.GetWebMenuById(pid);
            return data.Title;
        }


        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var firstMenu = await _webMenuSvc.GetWebMenuListByParentId(Guid.Empty);
            SelectList firstMenuSelectList = new SelectList(firstMenu,"Id","Title");
            ViewBag.FirstMenu = firstMenuSelectList;

            if (firstMenu.Count > 0)
            {
                var sonMenu = await _webMenuSvc.GetWebMenuListByParentId(firstMenu[0].Id);
                SelectList sonMenuList = new SelectList(sonMenu,"Id","Title");
                ViewBag.SecondMenu = sonMenuList;
            }

            return View(new AddWebMenuViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddWebMenuViewModel model,string[] level)
        {
            if (ModelState.IsValid)
            {
                if (level[0] == "0")
                {
                    model.ParentId = Guid.Empty;
                }
                else if (level[0] == "1")
                {
                    model.ParentId = Guid.Parse(level[1]);
                }
                else if (level[0] == "2")
                {
                    model.ParentId = Guid.Parse(level[2]);
                }

                var rs = await _webMenuSvc.AddWebMenu(model.Title, model.Link, model.Icon, model.ParentId);
                if (rs > 0)
                {
                    return msg.Show("新增成功",Url.Action("List","WebMenuManager"));
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var data = await _webMenuSvc.GetWebMenuById(id);
            int level = 0; //用于记录等级
            Guid parentId = Guid.Empty;
            Guid sonId = Guid.Empty;

            if (data.ParentId == Guid.Empty)
            {
                level = 0;
            }
            else
            {
                var parent = await _webMenuSvc.GetWebMenuById(data.ParentId);
                if (parent.ParentId == Guid.Empty)
                {
                    level = 1;
                    parentId = parent.Id;
                }
                else
                {
                    level = 2;
                    parentId = parent.ParentId;
                    sonId = parent.Id;
                }
            }

            Dictionary<string ,string > dic = new Dictionary<string, string>();
            dic.Add("0", "一级菜单");
            dic.Add("1", "二级菜单");
            dic.Add("2", "三级菜单");

            var secondMenus = await _webMenuSvc.GetWebMenuListByParentId(Guid.Empty);
            var thridMenus = await _webMenuSvc.GetWebMenuListByParentId(parentId);

            SelectList first = new SelectList(dic,"key","value",level);
            SelectList second = new SelectList(secondMenus,"Id","Title",parentId);
            SelectList third = new SelectList(thridMenus,"Id","Title",sonId);

            ViewBag.First = first;
            ViewBag.Second = second;
            ViewBag.Third = third;

            return View(new EditWebMenuViewModel()
            {
                Id = data.Id,
                Title = data.Title,
                Link = data.Link,
                ParentId = data.ParentId,
                Icon = data.Icon
            });

        }


        public async Task<JsonResult> ChangeMenuValue(Guid pid)
        {
            var son = await _webMenuSvc.GetWebMenuListByParentId(pid);
            return Json(son, JsonRequestBehavior.DenyGet);
        }



        public async Task<ActionResult> Edit(EditWebMenuViewModel model, string[] level)
        {
            if (ModelState.IsValid)
            {
                if (level[0] == "0")
                {
                    model.ParentId = Guid.Empty;
                }
                else if (level[0] == "1")
                {
                    model.ParentId = Guid.Parse(level[1]);
                }
                else if (level[0] == "2")
                {
                    model.ParentId = Guid.Parse(level[2]);
                }

                var rs = await _webMenuSvc.EditWebMenu(model.Id,model.Title, model.Link, model.Icon, model.ParentId);
                if (rs > 0)
                {
                    return msg.Show("编辑成功", Url.Action("List", "WebMenuManager"));
                }
            }

            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var rs = await _webMenuSvc.DeleteWebMenu(id);
            if (rs == -2)
            {
                
                return msg.Show("传输数据丢失,请稍后再试", Url.Action("List", "WebMenuManager"));
            }
            else if (rs > 0)
            {
                return msg.Show("删除成功", Url.Action("List", "WebMenuManager"));
            }
            else
            {
                return msg.Show("删除失败", Url.Action("List", "WebMenuManager"));
            }
        }
    }
}