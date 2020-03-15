using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class SeoDal : BaseDAL<Seo>,ISeoDal
    {
        public SeoDal() : base(new BlogSystemContext())
        {
        }
    }
}