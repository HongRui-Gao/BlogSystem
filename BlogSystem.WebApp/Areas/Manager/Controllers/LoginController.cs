using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BlogSystem.IBLL;
using BlogSystem.WebApp.Areas.Manager.Data.Login;

namespace BlogSystem.WebApp.Areas.Manager.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminsBll _adminsSvc;

        public LoginController(IAdminsBll adminsSvc)
        {
            _adminsSvc = adminsSvc;
        }

        [HttpGet]
        public ActionResult SignIn()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = await _adminsSvc.LoginAsync(model.Email, model.Password);
                if (data != null)
                {
                    //这个是账号密码正确
                    //我们需要判断是否记住这个账号密码
                    if (model.RememberMe)
                    {
                        HttpCookie u_cookie = new HttpCookie("LoginOk",data.Email);
                        HttpCookie r_cookie = new HttpCookie("RolesId",data.RolesId.ToString());
                        u_cookie.Expires = DateTime.Now.AddDays(7);
                        r_cookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(u_cookie);
                        Response.Cookies.Add(r_cookie);
                    }
                    else
                    {
                        Session["LoginOk"] = data.Email;
                        Session["RolesId"] = data.RolesId;
                    }

                    return RedirectToAction("Welcome", "Main");
                }
            }

            return View(model);
        }
    }
}