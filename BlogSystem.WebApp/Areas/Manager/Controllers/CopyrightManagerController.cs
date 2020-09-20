using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Common;
using BlogSystem.WebApp.Areas.Manager.Data.Copyright;
using BlogSystem.WebApp.Filter;
using CodeCarvings.Piczard;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    [AdminAuthorize]
    public class CopyrightManagerController : Controller
    {

        private ICopyrightBll _bll;
        public CopyrightManagerController(ICopyrightBll bll)
        {
            _bll = bll;
        }
        MessageBox msg = new MessageBox();
        [HttpGet]
        public async Task<ActionResult> List()
        {

            //在这个地方我们去查询第一个值
            var data = await _bll.GetCopyrightAsync();
            if (data != null)
                return View(new CopyrightViewModel
                {
                    Id = data.Id,
                    Title = data.Title,
                    Detail = data.Detail,
                    Telephone = data.Telephone,
                    Mobile = data.Mobile,
                    Logo = data.Logo,
                    Images = data.Images,
                    Address = data.Address,
                    Email = data.Email,
                    QQNumber = data.QQNumber,
                    QQNumber2 = data.QQNumber2,
                    Wechat = data.Wechat,
                    UpdateTime = data.UpdateTime
                });
            else
                return View(new CopyrightViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CopyrightViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var logo = Request.Files["myLogo"];
                var imgs = Request.Files["myImages"];
                string[] logo_names = null;
                string[] imgs_names = null;
                if (logo != null)
                    logo_names = UploadFiles(logo, @"../../Upload/Copyright/");
                else
                    logo_names =new string[] { "",""};
                if (imgs != null)
                    imgs_names  = UploadFiles(imgs, @"../../Upload/Copyright/");
                else
                    imgs_names = new string[] { "",""};
                int rs = 0;
                if (model.Id == Guid.Empty)
                {
                    //我们执行的内容是新增
                   rs =  await _bll.AddCopyrightAsync(model.Title, model.Detail, model.Telephone, model.Mobile, logo_names[0], imgs_names[0], model.Email, model.Address, model.QQNumber, model.QQNumber2, model.Wechat);
                }
                else 
                {
                    //否则的情况是修改
                    rs = await _bll.EditCopyrightAsync(model.Id, model.Title, model.Detail, model.Telephone, model.Mobile, logo_names[0], imgs_names[0], model.Email, model.Address, model.QQNumber, model.QQNumber2, model.Wechat);
                }

                if (rs > 0)
                {
                    return msg.Show("编辑成功", Url.Action("List", "CopyrightManager"));
                }
               
            }
            return msg.Show("编辑失败", Url.Action("List", "CopyrightManager"));
        }



        public string[] UploadFiles(HttpPostedFileBase file, string url)
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
                job.Filters.Add(new FixedResizeConstraint(24, 24));
                //202004041437051234_sm.png
                var sm_name = newName.Substring(0, newName.LastIndexOf('.'))
                                     + "_sm"
                                     + newName.Substring(newName.LastIndexOf('.'));
                var sm_path = Server.MapPath(url + sm_name);
                job.SaveProcessedImageToFileSystem(path, sm_path);
                return new string[] { newName, sm_name };
            }

            return new string[] { "", "" };
        }


    }
}