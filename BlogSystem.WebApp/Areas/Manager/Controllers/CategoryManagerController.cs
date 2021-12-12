using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.Category;
using BlogSystem.WebApp.Filter;
using PagedList;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class CategoryManagerController : Controller
    {
        private ICategoryBll _bll;

        public CategoryManagerController(ICategoryBll bll)
        {
            _bll = bll;
        }
        
        [HttpGet]
        public async Task<ActionResult> List(string Search = "",int page = 1)
        {
            var data = await _bll.GetDataByTitleAsync(Search);
            var list = data.Select(c => new CategoryListViewModel 
            {
                Id= c.Id,
                Title =c.Title,
                Details =c.Details,
                UpdateTime =c.UpdateTime

            }).ToList();

            ViewBag.Search = Search;
            ViewBag.PageIndex = page;
            IPagedList<CategoryListViewModel> pages = list.ToPagedList(page, PageConfig.GetPageSize());
            return View(pages);
        }


        [HttpGet]
        public ActionResult Add() 
        {
            return View(new CategoryAddViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoryAddViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await _bll.AddCategoryAsync(model.Title, model.Details);
                if (res > 0)
                    return RedirectToAction("List");
            }
            return View(model);
        }



        [HttpGet]
        public async Task<JsonResult> ValidateTitle(string Title) 
        {
           var result = await _bll.IsExistsAsync(Title);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid id) 
        {
            var data = await _bll.GetCategoryByIdAsync(id);

            if (data != null)
            {
                return View(new CategoryEditViewModel
                {
                    Id = data.Id,
                    Title = data.Title,
                    Details = data.Details
                });
            }
            else 
            {
                return RedirectToAction("List");
            }
           
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryEditViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                int res = await _bll.EditCategoryAsync(model.Id, model.Title, model.Details);
                if (res > 0)
                    return RedirectToAction("List");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid id) 
        {
            await _bll.DeleteCategoryAsync(id);
            return RedirectToAction("List");
        }









    }
}