using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.Seo;
using BlogSystem.WebApp.Filter;
using PagedList;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class SeoManagerController : Controller
    {
        private ISeoBll _seoSvc;
        private IWebMenuBll _webMenuSvc;

        public SeoManagerController(ISeoBll seoSvc, IWebMenuBll webMenuSvc)
        {
            _seoSvc = seoSvc;
            _webMenuSvc = webMenuSvc;
        }
        MessageBox msg = new MessageBox();
        [HttpGet]
        public async Task<ActionResult> List(string Search = "", int page = 1)
        {
            var data = await _seoSvc.GetSeoListByTitle(Search);

            var list = new List<SeoListViewModel>();

            foreach (var item in data)
            {
                SeoListViewModel slvm = new SeoListViewModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Keyword = item.Keyword,
                    Description = item.Description,
                    WebMenuTitle = await GetMenuTitle(item.WebMenuId),
                    UpdateTime = item.UpdateTime
                };
                list.Add(slvm);
            }

            IPagedList<SeoListViewModel> pages = list.ToPagedList(page, PageConfig.GetPageSize());
            ViewBag.Search = Search;
            return View(pages);
        }


        public async Task<string> GetMenuTitle(Guid webMenuId)
        {
            var data = await _webMenuSvc.GetWebMenuById(webMenuId);
            return data.Title;
        }


        [HttpGet]
        public async Task<ActionResult> Add()
        {
            //1. 绑定一个下拉列表
            await  Bind(Guid.Empty);

            return View(new AddSeoViewModel());
        }


        public async Task Bind(Guid webMenuId)
        {
            var data = await _webMenuSvc.GetWebMenuList();
           
            if (webMenuId != Guid.Empty)
            {
               
                SelectList sl = new SelectList(data, "Id", "Title",webMenuId);
                ViewBag.DropDownList = sl;
            }
            else
            {
                SelectList sl = new SelectList(data, "Id", "Title");
                ViewBag.DropDownList = sl;
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddSeoViewModel model)
        {
            if (ModelState.IsValid)
            {
               var res = await _seoSvc.AddSeoAsync(model.Title, model.Keyword, model.Description, model.WebMenuId);
               if (res > 0)
               {
                  return msg.Show("新增成功", Url.Action("List", "SeoManager"));
               }
            }
         
             return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id) 
        {
            var data = await _seoSvc.GetSeo(id);
            if (data != null)
            {
                //这个地方是数据不为空的情况
                EidtSeoViewModel slvm = new EidtSeoViewModel
                {
                    Id = data.Id,
                    Title = data.Title,
                    Description = data.Description,
                    Keyword = data.Keyword,
                    WebMenuId = data.WebMenuId
                };
               

                await Bind(data.WebMenuId);
                return View(slvm);
            }
            else 
            {
                return msg.Show("数据丢失,请重新尝试", Url.Action("List", "SeoManager"));
            }


        }

        [HttpPost]
        public async Task<ActionResult> Edit(EidtSeoViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                //这个地方是我们需要执行修改的地方

                var rs = await _seoSvc.EditSeoAsync(model.Id, model.Title, model.Keyword, model.Description, model.WebMenuId);
                if (rs > 0) 
                {
                    return msg.Show("编辑成功", Url.Action("List", "SeoManager"));
                }
            }

            await Bind(model.WebMenuId);
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(Guid id) 
        {
            var rs = await _seoSvc.DeleteSeoAsync(id);
            if (rs > 0)
            {
                return msg.Show("删除成功", Url.Action("List", "SeoManager"));
            }
            else 
            {
                return msg.Show("删除失败", Url.Action("List", "SeoManager"));
            }
        }


    }
}