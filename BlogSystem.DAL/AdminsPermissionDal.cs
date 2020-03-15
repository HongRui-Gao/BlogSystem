using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class AdminsPermissionDal : BaseDAL<AdminsPermission>,IAdminsPermissionDal
    {
        public AdminsPermissionDal() : base(new BlogSystemContext())
        {
        }
    }
}