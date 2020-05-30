using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.Roles;
using BlogSystem.WebApp.Filter;
using log4net;
using log4net.Core;
using PagedList;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
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
           // var count = await _rolesBll.GetRolesCountAsync(Search);
            
            //(3) 设置每页要展示条数
            var pageSize = PageConfig.GetPageSize();

            var data = await _rolesBll.GetRolesList(Search,false);
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
            ViewBag.PageIndex = page;
            IPagedList<RolesListViewModel> pages = list.ToPagedList(page, PageConfig.GetPageSize());
            return View(pages);
        }


        [HttpGet]
        public ActionResult Add() 
        {
            return View(new AddRolesViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddRolesViewModel roles) 
        {
            if (ModelState.IsValid) 
            {
                //验证合法,我们在这进行执行新增操作
                int rs = await _rolesBll.AddRolesAsync(roles.Title);
                if (rs > 0)
                {
                    Response.Write("<script>alert('新增成功');location.href='../../Manager/RolesManager/List'</script>");
                }
                else 
                {
                    return View(roles);
                }
            }
            return View(roles);
        }


        /// <summary>
        /// 做唯一验证的
        /// </summary>
        /// <param name="Title"></param>
        /// <returns></returns>
        public async Task<JsonResult> CheckRolesTitle(string Title) 
        {
            var rs = await _rolesBll.IsExistsAsync(Title);
            return Json(!rs, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            var data = await _rolesBll.GetRolesAsync(id);
            return View(new EditRolesViewModel()
            {
                Id = data.Id,
                Title = data.Title
            });
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditRolesViewModel roles)
        {
            if (ModelState.IsValid)
            {
                var rs = await _rolesBll.EditRolesAsync(roles.Id, roles.Title);
                if (rs > 0)
                {
                    Response.Write("<script>alert('编辑成功');location.href='../../../Manager/RolesManager/List'</script>");
                }
            }

            return View(roles);
        }

        [HttpGet]
        public async Task Delete(Guid id)
        {
            var rs = await _rolesBll.DeleteRolesAsync(id);
            if (rs > 0)
            {
                Response.Write("<script>alert('删除成功');location.href='../../../Manager/RolesManager/List'</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败');location.href='../../../Manager/RolesManager/List'</script>");
            }
        }
    }
}