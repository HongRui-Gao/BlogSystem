using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlogSystem.Models;

using BlogSystem.IDAL;
namespace BlogSystem.DAL
{
    public class AboutDal : BaseDAL<About>,IAboutDal
    {
        public AboutDal() : base(new BlogSystemContext())
        {
        }
    }
}
