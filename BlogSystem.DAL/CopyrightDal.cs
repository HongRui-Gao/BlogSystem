using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class CopyrightDal : BaseDAL<Copyright>,ICopyrightDal
    {
        public CopyrightDal() : base(new BlogSystemContext())
        {
        }
    }
}