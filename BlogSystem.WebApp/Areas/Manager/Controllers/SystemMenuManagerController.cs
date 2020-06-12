using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.SystemMenu;
using BlogSystem.WebApp.Filter;
using PagedList;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class SystemMenuManagerController : Controller
    {
        private ISystemMenuBll _bll;

        public SystemMenuManagerController(ISystemMenuBll bll)
        {
            _bll = bll;
        }
        MessageBox msg = new MessageBox();
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


        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var firstMenu = await _bll.GetSystemMenuListByParentId(Guid.Empty);
            SelectList firstMenuList = new SelectList(firstMenu,"Id","Title");
            ViewBag.FirstMenu = firstMenuList;

            if (firstMenu.Count > 0)
            {
                var sonMenu = await _bll.GetSystemMenuListByParentId(firstMenu[0].Id);
                SelectList sonMenuList = new SelectList(firstMenu, "Id", "Title");
                ViewBag.SecondMenu = sonMenuList;
            }

            return View(new AddSystemMenuViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddSystemMenuViewModel model, string[] level)
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

                int rs = await _bll.AddSystemMenuAsync(model.Title, model.Link, model.Icon, model.ParentId);
                if (rs > 0)
                {
                   return msg.Show("新增成功", Url.Action("List", "SystemMenuManager"));
                }

            }

            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {

            var model = await _bll.GetSystemMenu(id);
            int level = 0; //用于记录菜单的等级
            Guid parentId = Guid.Empty; //记录父级菜单id的
            Guid sonId = Guid.Empty; //用于记录子级菜单id的
             
            if (model.ParentId == Guid.Empty) //当当前对象的父级菜单id为空的时候代表为一级菜单
            {
                level = 0;
            }
            else //可能是二级菜单 或 三级菜单
            {
                var data = await _bll.GetSystemMenu(model.ParentId);
                if (data.ParentId == Guid.Empty)  //父级菜单的 父级id为空则为二级菜单
                {
                    level = 1;
                    parentId = data.Id;
                }
                else //否则为三级菜单
                {
                    level = 2;
                    parentId = data.ParentId;
                    sonId = data.Id;
                }
            }

            //下拉列表的值绑定
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("0", "一级菜单");
            dic.Add("1", "二级菜单");
            dic.Add("2", "三级菜单");

            var secondMenus = await _bll.GetSystemMenuListByParentId(Guid.Empty);
            var thirdMenus = await _bll.GetSystemMenuListByParentId(parentId);

            SelectList first = new SelectList(dic, "key", "value", level);
            SelectList second = new SelectList(secondMenus, "Id", "Title", parentId);
            SelectList third = new SelectList(thirdMenus, "Id", "Title", sonId);

            ViewBag.First = first;
            ViewBag.Second = second;
            ViewBag.Third = third;

            return View(new EditSystemMenuViewModel {
                Id = model.Id,
                Title = model.Title,
                Link = model.Link,
                ParentId = model.ParentId,
                Icon = model.Icon
            
            });

        }


        public async Task<JsonResult> ChangeMenuValue(Guid pid) 
        {
            var son = await _bll.GetSystemMenuListByParentId(pid);
            return Json(son, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditSystemMenuViewModel model, string[] level) 
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

                var res = await _bll.EditSystemMenuAsync(model.Id, model.Title, model.Link, model.Icon, model.ParentId);
                if (res > 0)
                {
                    return msg.Show("编辑成功", Url.Action("List", "SystemMenuManager"));
                }
                else 
                {
                    return View(model);
                }
            }
            else 
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid id) 
        {
            var res = await _bll.DeleteSystemMenuAsync(id);
            if (res == -2)
            {
                return msg.Show("传输数据丢失,请稍后再试", Url.Action("List", "SystemMenuManager"));
                
            }
            else if (res > 0)
            {
                return msg.Show("删除成功", Url.Action("List", "SystemMenuManager"));
            }
            else 
            {
                return msg.Show("删除失败", Url.Action("List", "SystemMenuManager"));
            }
            
        }
    }
}