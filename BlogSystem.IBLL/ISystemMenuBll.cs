using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogSystem.Dtos;

namespace BlogSystem.IBLL
{
    public interface ISystemMenuBll
    {

        Task<int> AddSystemMenuAsync(string title, string link, string icon, Guid parentId);

        Task<int> EditSystemMenuAsync(Guid id,string title, string link, string icon, Guid parentId);

        Task<int> DeleteSystemMenuAsync(Guid id);

        Task<List<SystemMenuDto>> GetSystemMenuListByTitle(string title);

        Task<List<SystemMenuDto>> GetSystemMenuListByParentId(Guid pid);

        Task<SystemMenuDto> GetSystemMenu(Guid id);

    }
}