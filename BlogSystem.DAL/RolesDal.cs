using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class RolesDal : BaseDAL<Roles>,IRolesDal
    {
        public RolesDal() : base(new BlogSystemContext())
        {
        }
    }
}