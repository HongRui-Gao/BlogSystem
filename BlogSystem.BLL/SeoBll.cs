using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using BlogSystem.Dtos;
using BlogSystem.IBLL;
using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.BLL
{
    public class SeoBll : ISeoBll
    {
        private ISeoDal _dal;

        public SeoBll(ISeoDal dal)
        {
            _dal = dal;
        }


        public async Task<int> AddSeoAsync(string title, string keyword, string description, Guid webMenuId)
        {
            return await _dal.AddAsync(new Seo()
            {
                Title =  title,
                Keyword = keyword,
                Description = description,
                WebMenuId =  webMenuId
            });
        }

        public async Task<int> EditSeoAsync(Guid id, string title, string keyword, string description, Guid webMenuId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
            {
                return -2;
            }

            data.Title = title;
            data.Keyword = keyword;
            data.Description = description;
            data.WebMenuId = webMenuId;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public async Task<int> DeleteSeoAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -2;
            return await _dal.DeleteAsync(data);
        }

        public async Task<List<SeoDto>> GetAll()
        {
            return await _dal.Query().Select(seo => new SeoDto()
            {
                Id = seo.Id,
                Title =  seo.Title,
                Keyword = seo.Keyword,
                Description = seo.Description,
                WebMenuId = seo.WebMenuId,
                UpdateTime = seo.UpdateTime
            }).ToListAsync();
        }

        public async Task<List<SeoDto>> GetSeoListByTitle(string title)
        {
            return await _dal.Query(seo => seo.Title.Contains(title)).Select(seo => new SeoDto()
            {
                Id = seo.Id,
                Title = seo.Title,
                Keyword = seo.Keyword,
                Description = seo.Description,
                WebMenuId = seo.WebMenuId,
                UpdateTime = seo.UpdateTime
            }).ToListAsync();
        }

        public async Task<List<SeoDto>> GetSeoListByWebMenuId(Guid webMenuId)
        {
            return await _dal.Query(seo => seo.WebMenuId == webMenuId).Select(seo => new SeoDto()
            {
                Id = seo.Id,
                Title = seo.Title,
                Keyword = seo.Keyword,
                Description = seo.Description,
                WebMenuId = seo.WebMenuId,
                UpdateTime = seo.UpdateTime
            }).ToListAsync();
        }

        public async Task<SeoDto> GetSeo(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return null;
            return new SeoDto()
            {
                Id = data.Id,
                Title = data.Title,
                Keyword = data.Keyword,
                Description = data.Description,
                WebMenuId = data.WebMenuId,
                UpdateTime = data.UpdateTime
            };
        }
    }
}