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

        public async Task<int> EditAdminsAsync(Guid id, string email,string password, string nickname, string photo, string images, Guid rolesId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            data.Email = email;
            if(images != null)
                data.Images = images;
            data.NickName = nickname;
            data.Password = password;
            if(photo != null)
                data.Photo = photo;
            data.RolesId = rolesId;
            return await _dal.EditAsync(data);
        }

        public async Task<int> DeleteAdminsAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data != null)
                return await _dal.DeleteAsync(data);
            return -2;
        }

        public async Task<AdminsDto> LoginAsync(string email, string password)
        {
            return await _dal.Query(admin => admin.Email.Equals(email) && admin.Password.Equals(password))
                .Select(a => new AdminsDto()
                {
                    Id = a.Id,
                    Email = a.Email,
                    Password = a.Password,
                    NickName = a.NickName,
                    RolesId = a.RolesId,
                    Photo = a.Photo,
                    Images = a.Images,
                    UpdateTime = a.UpdateTime
                }).FirstOrDefaultAsync();
        }

        public async Task<List<AdminsDto>> GetAllAdminsAsync()
        {
            return await _dal.Query().Select(a => new AdminsDto()
            {
                Id = a.Id,
                Email = a.Email,
                Password = a.Password,
                NickName = a.NickName,
                RolesId = a.RolesId,
                Photo = a.Photo,
                Images = a.Images,
                UpdateTime = a.UpdateTime
            }).ToListAsync();
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

        public async Task<AdminsDto> GetAdminsByEmail(string email)
        {
            return await _dal.Query(a => a.Email.Equals(email)).Select(a => new AdminsDto()
            {
                Id = a.Id,
                Email = a.Email,
                Password = a.Password,
                NickName = a.NickName,
                RolesId = a.RolesId,
                Photo = a.Photo,
                Images = a.Images,
                UpdateTime = a.UpdateTime
            }).FirstOrDefaultAsync();
        }

        public async Task<AdminsDto> GetAdminsById(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data != null)
            {
                return new AdminsDto()
                {
                    Id = data.Id,
                    Email = data.Email,
                    Images = data.Images,
                    NickName = data.NickName,
                    Password = data.Password,
                    Photo = data.Photo,
                    RolesId = data.RolesId,
                    UpdateTime = data.UpdateTime
                };
            }

            return null;

        }

        public async Task<List<AdminsDto>> GetAdminsByRolesId(Guid rid)
        {
            return await _dal.Query(a => a.RolesId == rid).Select(a => new AdminsDto()
            {
                Id = a.Id,
                Email = a.Email,
                Password = a.Password,
                NickName = a.NickName,
                RolesId = a.RolesId,
                Photo = a.Photo,
                Images = a.Images,
                UpdateTime = a.UpdateTime
            }).ToListAsync();
        }
    }
}