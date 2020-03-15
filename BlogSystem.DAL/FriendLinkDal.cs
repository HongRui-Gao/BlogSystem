using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class FriendLinkDal : BaseDAL<FriendLink>,IFriendLinkDal
    {
        public FriendLinkDal() : base(new BlogSystemContext())
        {
        }
    }
}