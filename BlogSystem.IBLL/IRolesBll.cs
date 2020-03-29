using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlogSystem.Dtos;

namespace BlogSystem.IBLL
{
    public interface IRolesBll
    {
        Task<int> AddRolesAsync(string title);

        Task<int> EditRolesAsync(Guid id, string title);

        Task<int> DeleteRolesAsync(Guid id);

        Task<int> GetRolesCountAsync(string title);

        Task<bool> IsExistsAsync(string title);

        Task<List<RolesDto>> GetRolesListByPageAsync(int pageSize, int pageIndex, string title, bool isAsc);

        Task<RolesDto> GetRolesAsync(Guid id);

        Task<List<RolesDto>> GetRolesList(string title, bool isAsc); //这个是带有分页插件的查询
    }
}