using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class MessageDal : BaseDAL<Message> , IMessageDal
    {
        public MessageDal() : base(new BlogSystemContext())
        {

        }
    }
}
