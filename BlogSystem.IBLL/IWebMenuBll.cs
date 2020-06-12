using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogSystem.Dtos;

namespace BlogSystem.IBLL
{
    public interface IWebMenuBll
    {
        Task<int> AddWebMenu(string title, string link, string icon, Guid parentId);

        Task<int> EditWebMenu(Guid id,string title, string link, string icon, Guid parentId);

        Task<int> DeleteWebMenu(Guid id);

        Task<List<WebMenuDto>> GetWebMenuList();

        Task<List<WebMenuDto>> GetWebMenuListByTitle(string title);

        Task<List<WebMenuDto>> GetWebMenuListByParentId(Guid id);

        Task<WebMenuDto> GetWebMenuById(Guid id);
    }
}