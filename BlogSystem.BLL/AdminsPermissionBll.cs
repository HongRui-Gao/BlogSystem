using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BlogSystem.Dtos;
using BlogSystem.IBLL;
using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.BLL
{
    public class AdminsPermissionBll : IAdminsPermissionBll
    {

        private IAdminsPermissionDal _dal;

        public AdminsPermissionBll(IAdminsPermissionDal dal)
        {
            _dal = dal;
        }


        public async Task<List<AdminsPermissionDto>> GetAdminsPermissionListByRolesId(Guid rolesId)
        {
            return await _dal.Query(ap => ap.RolesId == rolesId)
                .Select(ap => new AdminsPermissionDto()
                {
                    Id = ap.Id,
                    RolesId = ap.RolesId,
                    SystemMenuId = ap.SystemMenuId,
                    UpdateTime = ap.UpdateTime
                }).ToListAsync();
        }

        public async Task<int> AddAdminsPermission(Guid rolesId, Guid systemMenuId)
        {
            var data = _dal.Query(ap => ap.RolesId == rolesId && ap.SystemMenuId == systemMenuId);

            if (data.Any())
            {
                return -2;
            }

            return await _dal.AddAsync(new AdminsPermission()
            {
                RolesId = rolesId,
                SystemMenuId = systemMenuId
            });

        }

        public async Task<int> DeleteAdminsPermission(Guid rolesId, Guid systemMenuId)
        {
            var data = _dal.Query(ap => ap.RolesId == rolesId && ap.SystemMenuId == systemMenuId);

            if (data.Any())
            {
                return await _dal.DeleteAsync(data.First());
            }

            return -2;
        }
    }
}