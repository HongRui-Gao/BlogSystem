using BlogSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface ICopyrightBll
    {

        Task<int> AddCopyrightAsync(string title,string detail,string telephone ,string mobile ,string logo,string images,string email,string address,string qqNumber,string qqNumber2,string wechat );

        Task<int> EditCopyrightAsync(Guid id,string title, string detail, string telephone, string mobile, string logo, string images, string email, string address, string qqNumber, string qqNumber2, string wechat);

        Task<CopyrightDto> GetCopyrightAsync(Guid id);

        Task<CopyrightDto> GetCopyrightAsync();

    }
}
