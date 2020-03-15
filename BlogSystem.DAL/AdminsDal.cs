using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class AdminsDal:BaseDAL<Admins>,IAdminsDal
    {
        public AdminsDal() : base(new BlogSystemContext())
        {
        }
    }
}