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
    public class AdminsBll : IAdminsBll
    {
        private IAdminsDal _dal;

        public AdminsBll(IAdminsDal dal)
        {
            _dal = dal;
        }

        public async Task<int> AddAdminsAsync(string email, string password, string nickname, string photo,string images, Guid rolesId)
        {
            return await _dal.AddAsync(new Admins()
            {
                Email = email,
                Password = password,
                NickName = nickname,
                Photo = photo,
                Images = images,
                RolesId =  rolesId
            });
        }

        public async Task<int> EditAdminsAsync(Guid id, string password, string nickname, string photo, string images, Guid rolesId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAdminsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminsDto> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdminsDto>> GetAllAdminsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdminsDto>> GetAdminsByNickName(string nickname)
        {
            return await _dal.Query(a => a.NickName.Contains(nickname))
                             .OrderByDescending(a => a.UpdateTime)
                             .Select(a => new AdminsDto()
                             {
                                 Id = a.Id,
                                 Email = a.Email,
                                 Password = a.Password,
                                 NickName =  a.NickName,
                                 RolesId = a.RolesId,
                                 Photo =  a.Photo,
                                 Images = a.Images,
                                 UpdateTime = a.UpdateTime
                             })
                             .ToListAsync();
        }

        public async Task<bool> IsExists(string email)
        {
            return await _dal.IsExistsAsync(am => am.Email.Equals(email));
        }

        public async Task<List<AdminsDto>> GetAdminsByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<AdminsDto> GetAdminsById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AdminsDto>> GetAdminsByRolesId(Guid rid)
        {
            throw new NotImplementedException();
        }
    }
}