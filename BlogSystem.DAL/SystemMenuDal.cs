using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class SystemMenuDal : BaseDAL<SystemMenu>,ISystemMenuDal
    {
        public SystemMenuDal() : base(new BlogSystemContext())
        {
        }
    }
}