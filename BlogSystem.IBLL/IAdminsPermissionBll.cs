using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogSystem.Dtos;

namespace BlogSystem.IBLL
{
    public interface IAdminsPermissionBll
    {
        Task<List<AdminsPermissionDto>> GetAdminsPermissionListByRolesId(Guid rolesId);

        Task<int> AddAdminsPermission(Guid rolesId, Guid systemMenuId);

        Task<int> DeleteAdminsPermission(Guid rolesId, Guid systemMenuId);
    }
}