using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogSystem.Dtos;

namespace BlogSystem.IBLL
{
    public interface IAdminsBll
    {
        Task<int> AddAdminsAsync(string email, string password, string nickname, string photo, string images, Guid rolesId);

        Task<int> EditAdminsAsync(Guid id, string email, string password, string nickname, string photo, string images, Guid rolesId);

        Task<int> DeleteAdminsAsync(Guid id);

        Task<AdminsDto> LoginAsync(string email, string password);

        Task<List<AdminsDto>> GetAllAdminsAsync();

        Task<List<AdminsDto>> GetAdminsByNickName(string nickname);

        Task<bool> IsExists(string email);

        Task<AdminsDto> GetAdminsByEmail(string email);

        Task<AdminsDto> GetAdminsById(Guid id);

        Task<List<AdminsDto>> GetAdminsByRolesId(Guid rid);
    }
}