using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Data.LeftMenu;
using BlogSystem.WebApp.Filter;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class LayoutController : Controller
    {

        private IAdminsPermissionBll _permissionSvc;
        private ISystemMenuBll _menuSvc;

        public LayoutController(IAdminsPermissionBll permissionSvc,ISystemMenuBll menuSvc)
        {
            _permissionSvc = permissionSvc;
            _menuSvc = menuSvc;
        }

        /// <summary>
        /// 左边菜单绑定
        /// </summary>
        /// <returns>对应的Json字符串</returns>
        [HttpGet]
        public async Task<JsonResult> LeftMenuBind()
        {
            //1. 获取当前登入用户的权限id
            Guid rid = Guid.Empty;
            object ob = Session["RolesId"];
            if (ob == null) //如果我们通过Session获取的时候为空了,那么就是点击了记住密码用Cookie登入
            {
                HttpCookie rCookie = Request.Cookies["RolesId"];
                rid = Guid.Parse(rCookie.Value);
            }
            else
            {
                rid = Guid.Parse(ob.ToString());
            }

            //2. 通过权限id得到能看到的系统菜单id
            var permissions = await _permissionSvc.GetAdminsPermissionListByRolesId(rid);
            //3. 得到当前数据库当中所有的系统菜单详情,之后根据上面的系统菜单id进行筛选
            var allMenu = await _menuSvc.GetSystemMenuListByTitle("");

            var menus = (from sm in allMenu
                    where (from ap in permissions
                        select ap.SystemMenuId).Contains(sm.Id)
                    select sm
                ).ToList();
            //4. 在上面得到所有能看到菜单当中找出一级菜单
            var parents = menus.Where(m => m.ParentId == Guid.Empty).OrderBy(m => m.UpdateTime);
            //5. 得到最后要往界面返回的集合内容
            List<LeftMenuListViewModel> list = new List<LeftMenuListViewModel>();

            foreach (var item in parents)
            {
                //1. 通过一级菜单的id查找对应的子级菜单
                List<LeftMenuListViewModel> sonList = new List<LeftMenuListViewModel>();
                var sonData = await _menuSvc.GetSystemMenuListByParentId(item.Id);
                foreach (var sonItem in sonData)
                {
                    LeftMenuListViewModel son = new LeftMenuListViewModel
                    {
                        Title = sonItem.Title,
                        Link = sonItem.Link,
                        Icon = sonItem.Icon
                    };
                    sonList.Add(son);
                }
                //下面填充的内容为直接展示的内容
                LeftMenuListViewModel lmlvm = new LeftMenuListViewModel
                {
                    Title = item.Title,
                    Icon = item.Icon,
                    Link = item.Link,
                    SonList = sonList
                };

                list.Add(lmlvm);
            }

            return Json(list,JsonRequestBehavior.AllowGet);
        }

    }
}