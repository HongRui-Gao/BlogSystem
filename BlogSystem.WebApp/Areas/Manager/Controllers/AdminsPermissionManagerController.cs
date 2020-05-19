using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Data.AdminsPermisson;
using BlogSystem.WebApp.Areas.Manager.Data.Roles;
using BlogSystem.WebApp.Areas.Manager.Data.SystemMenu;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    public class AdminsPermissionManagerController : Controller
    {
        private IRolesBll _rolesSvc;
        private ISystemMenuBll _menuSvc;
        private IAdminsPermissionBll _permissonSvc;

        public AdminsPermissionManagerController(IRolesBll rolesSvc,ISystemMenuBll menuSvc,IAdminsPermissionBll permissonSvc)
        {
            _rolesSvc = rolesSvc;
            _menuSvc = menuSvc;
            _permissonSvc = permissonSvc;
        }


        [HttpGet]
        public async Task<ActionResult> List()
        {
            await RolesListBind(Guid.Empty);
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> List(RolesListViewModel roles)
        {
            await RolesListBind(roles.Id); //这个是下拉列表的绑定

            var permissionList = await _permissonSvc.GetAdminsPermissionListByRolesId(roles.Id);
            var data = await _menuSvc.GetSystemMenuListByTitle(""); //查询所有的系统菜单列表
            var allMenuList = new List<SystemMenuListViewModel>();
            foreach (var item in data)
            {
                SystemMenuListViewModel smvm = new SystemMenuListViewModel
                {
                    Id = item.Id,
                    Title = item.Title
                };
                allMenuList.Add(smvm);
            }

            var haveData = (from sm in allMenuList
                            where (from ap in permissionList select ap.SystemMenuId).Contains(sm.Id)
                            select sm).ToList();

            var noneHave = (from sm in allMenuList
                where !(from ap in permissionList select ap.SystemMenuId).Contains(sm.Id)
                select sm).ToList();

            ViewBag.HaveList = haveData;
            ViewBag.NoHave = noneHave;
            return View();
        }


        private async Task RolesListBind(Guid selectedId)
        {
            var data = await _rolesSvc.GetRolesList("", true);
            var rolesList = new List<RolesListViewModel>();
            foreach (var item in data)
            {
                RolesListViewModel rlvm = new RolesListViewModel
                {
                    Id = item.Id,
                    Title = item.Title
                };
                rolesList.Add(rlvm);
            }
            if (selectedId == Guid.Empty)
            {
                SelectList sl = new SelectList(rolesList, "Id", "Title");
                ViewBag.Roles = sl;
            }
            else
            {
                SelectList sl = new SelectList(rolesList, "Id", "Title",selectedId);
                ViewBag.Roles = sl;
                ViewBag.RolesId = selectedId;
            }
        }


        [HttpPost]
        public async Task<ActionResult> Add(AddAdminsPermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var menuId in model.SystemMenuId)
                {
                    await _permissonSvc.AddAdminsPermission(model.RolesId, menuId);
                }
            }

            return RedirectToAction("List", "AdminsPermissionManager");
        }


        [HttpPost]
        public async Task<ActionResult> Delete(DeleteAdminsPermissionViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.SystemMenuId)
                {
                    await _permissonSvc.DeleteAdminsPermission(model.RolesId, item);
                }
            }

            return RedirectToAction("List", "AdminsPermissionManager");
        }


    }
}