using System.Web.Mvc;

namespace BlogSystem.WebApp.Areas.Manager.Common
{
    public class MessageBox : Controller
    {
        public  ContentResult Show(string msg,string url)
        {
            return Content("<script>alert('"+msg+"');location.href='"+url+"'</script>");
        }
    }
}