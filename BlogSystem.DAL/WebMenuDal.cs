using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class WebMenuDal : BaseDAL<WebMenu>,IWebMenuDal
    {
        public WebMenuDal() : base(new BlogSystemContext())
        {
        }
    }
}