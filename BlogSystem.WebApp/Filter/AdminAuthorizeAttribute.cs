using System.Web;
using System.Web.Mvc;

namespace BlogSystem.WebApp.Filter
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        //这个里面主要做的,验证我们session和cookie当中是否有值,有值的时候我们就是登入之后,没值的时候需要登入
        //这个类我们需要继承一下AuthorizeAttribute

        /// <summary>
        /// 这个是没登入的情况下,跳转到登入界面
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Manager/Login/SignIn");
        }

        /// <summary>
        /// 验证session和cookie判断是否登入,返回布尔值,true是登入的,false没登入
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool rs = (httpContext.Session["LoginOk"] != null && httpContext.Session["RolesId"] != null)
                      ||
                      (httpContext.Request.Cookies["LoginOk"] != null &&
                       httpContext.Request.Cookies["RolesId"] != null);
            return rs;
        }
    }
}