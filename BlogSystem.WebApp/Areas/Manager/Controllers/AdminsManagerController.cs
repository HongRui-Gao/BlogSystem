using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.Admins;
using CodeCarvings.Piczard;
using PagedList;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    public class AdminsManagerController : Controller
    {
        private IAdminsBll _admins_bll;
        private IRolesBll _roles_bll;

        public AdminsManagerController(IAdminsBll admins_bll, IRolesBll roles_bll)
        {
            _admins_bll = admins_bll;
            _roles_bll = roles_bll;
        }
        public async Task<ActionResult> List(string Search = "", int page = 1)
        {
            var data = await _admins_bll.GetAdminsByNickName(Search);
            List<AdminsListViewModel> list = new List<AdminsListViewModel>();
            foreach (var item in data)
            {
                //先去通过当前这个item对象查看对应的权限信息
                var role = await _roles_bll.GetRolesAsync(item.RolesId); //这个地方存放的是权限id
                AdminsListViewModel alvm = new AdminsListViewModel()
                {
                    Id = item.Id,
                    Email = item.Email,
                    Password = item.Password,
                    Photo = item.Photo,
                    NickName = item.NickName,
                    UpdateTime = item.UpdateTime,
                    RolesTitle = role.Title //这个地方是把我们查询出来的权限名称放里
                };
                list.Add(alvm);
            }

            ViewBag.Search = Search;
            ViewBag.PageIndex = page;
            IPagedList<AdminsListViewModel> pages = list.ToPagedList(page, PageConfig.GetPageSize());
            return View(pages);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            await BindRoles(Guid.Empty);
            return View(new AddAdminsViewModel());
        }


        [HttpPost]
        public async Task<ActionResult> Add(AddAdminsViewModel model)
        {
            if (ModelState.IsValid)
            {
                //获取表单传递过来的数据,并且实现新增功能
                var file = Request.Files["MyPhoto"];

                var names = UploadFiles(file, @"../../Upload/Admins/"); //得到上传图片的名称

                var rs = await _admins_bll.AddAdminsAsync(model.Email, model.Password, model.NickName, names[0],
                    names[1], model.RolesId);
                if (rs > 0)
                {
                    return Content("<script>alert('新增成功');location.href='../../Manager/AdminsManager/List'</script>");
                }
                

            }

            return View(model);
        }

        /// <summary>
        /// 绑定权限下拉列表的
        /// </summary>
        /// <param name="id">当前选中的值</param>
        /// <returns></returns>
        public async Task BindRoles(Guid id)
        {
            //查询所有的权限信息
            var roles = await _roles_bll.GetRolesList("", true);
            //我们需要把这个集合传递给视图
            if (id == Guid.Empty)
            {
                SelectList rolesList = new SelectList(roles, "Id", "Title");
                ViewBag.RolesList = rolesList;
            }
            else
            {
                SelectList rolesList = new SelectList(roles, "Id", "Title", id);
                ViewBag.RolesList = rolesList;
            }
        }



        public string[] UploadFiles(HttpPostedFileBase file,string url)
        {
            if (!file.FileName.Equals(""))
            {
                Random r = new Random();
                var newName = DateTime.Now.ToString("yyyyMMddHHmmss") 
                                    + r.Next(1000, 10000) 
                                    + file.FileName.Substring(file.FileName.LastIndexOf('.'));
                var path = Server.MapPath(url + newName);

                file.SaveAs(path); //保存的正常大小的图片

                ImageProcessingJob job = new ImageProcessingJob(); //实例化第三方缩略图插件
                job.Filters.Add(new FixedResizeConstraint(24,24));
                //202004041437051234_sm.png
                var sm_name = newName.Substring(0, newName.LastIndexOf('.'))
                                     + "_sm"
                                     + newName.Substring(newName.LastIndexOf('.'));
                var sm_path = Server.MapPath(url + sm_name);
                job.SaveProcessedImageToFileSystem(path,sm_path);
                return new string[]{newName,sm_name};
            }

            return new string[]{ "default.jpeg","default.png"};
        }


        public async Task<JsonResult> CheckEmailAsync(string Email)
        {
            var rs = await _admins_bll.IsExists(Email);
            return Json(!rs, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]

        public async Task<ActionResult> Edit(Guid id)
        {
            var data = await  _admins_bll.GetAdminsById(id);

            await BindRoles(data.RolesId);

            return View(new EditAdminsViewModel()
            {
                Id = data.Id,
                Email = data.Email,
                Password = data.Password,
                NickName = data.NickName,
                Photo = data.Photo,
                RolesId = data.RolesId,
                Images = data.Images
            });

        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditAdminsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var file = Request.Files["MyPhoto"];
                var rs = -1;
                if (file.FileName != "" && file.FileName != null) //这个是我们修改头像时候的
                {
                    var names = UploadFiles(file, @"../../../Upload/Admins/");
                    rs = await _admins_bll.EditAdminsAsync(model.Id, model.Email, model.Password, model.NickName, names[0], names[1], model.RolesId);
                }
                else
                {
                    rs = await _admins_bll.EditAdminsAsync(model.Id, model.Email, model.Password, model.NickName,
                        model.Photo, model.Images, model.RolesId);
                }

                if (rs > 0)
                {
                    return Content("<script>alert('修改成功');location.href='../../../Manager/AdminsManager/List'</script>");
                }
            }

            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> Delete(Guid id)
        {
            var rs = await _admins_bll.DeleteAdminsAsync(id);
            if (rs > 0)
            {
                return Content("<script>alert('删除成功');location.href='../../../Manager/AdminsManager/List'</script>");
            }
            else if (rs == -2)
            {
                return Content("<script>alert('数据传输丢失,请稍后再试');location.href='../../../Manager/AdminsManager/List'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败');location.href='../../../Manager/AdminsManager/List'</script>");
            }
        }
    }
}