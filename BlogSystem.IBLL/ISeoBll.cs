using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogSystem.Dtos;

namespace BlogSystem.IBLL
{
    public interface ISeoBll
    {

        Task<int> AddSeoAsync(string title, string keyword, string description, Guid webMenuId);

        Task<int> EditSeoAsync(Guid id, string title, string keyword, string description, Guid webMenuId);

        Task<int> DeleteSeoAsync(Guid id);

        Task<List<SeoDto>> GetAll();

        Task<List<SeoDto>> GetSeoListByTitle(string title);

        Task<List<SeoDto>> GetSeoListByWebMenuId(Guid webMenuId);

        Task<SeoDto> GetSeo(Guid id);


    }
}