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
    public class WebMenuBll : IWebMenuBll
    {
        private IWebMenuDal _dal;

        public WebMenuBll(IWebMenuDal dal)
        {
            _dal = dal;
        }

        public async Task<int> AddWebMenu(string title, string link, string icon, Guid parentId)
        {
            return await _dal.AddAsync(new WebMenu()
            {
                Title =  title,
                Link = link,
                Icon = icon,
                ParentId = parentId
            });
        }

        public async Task<int> EditWebMenu(Guid id, string title, string link, string icon, Guid parentId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -2;
            data.Title = title;
            data.Link = link;
            data.Icon = icon;
            data.ParentId = parentId;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public async Task<int> DeleteWebMenu(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -2;
            return await _dal.DeleteAsync(data);
        }

        public async Task<List<WebMenuDto>> GetWebMenuList()
        {
            return await _dal.Query()
                .OrderByDescending(wm => wm.UpdateTime)
                .Select(wm => new WebMenuDto()
                {
                    Id = wm.Id,
                    Title = wm.Title,
                    Link = wm.Link,
                    Icon = wm.Icon,
                    ParentId = wm.ParentId,
                    UpdateTime = wm.UpdateTime
                })
                .ToListAsync();
        }

        public async Task<List<WebMenuDto>> GetWebMenuListByTitle(string title)
        {
            return await _dal.Query(wm => wm.Title.Contains(title))
                .OrderByDescending(wm => wm.UpdateTime)
                .Select(wm => new WebMenuDto()
                {
                    Id = wm.Id,
                    Title = wm.Title,
                    Link = wm.Link,
                    Icon = wm.Icon,
                    ParentId = wm.ParentId,
                    UpdateTime = wm.UpdateTime
                })
                .ToListAsync();
        }

        public async Task<List<WebMenuDto>> GetWebMenuListByParentId(Guid id)
        {
            return await _dal.Query(wm => wm.ParentId == id)
                .OrderByDescending(wm => wm.UpdateTime)
                .Select(wm => new WebMenuDto()
                {
                    Id = wm.Id,
                    Title = wm.Title,
                    Link = wm.Link,
                    Icon = wm.Icon,
                    ParentId = wm.ParentId,
                    UpdateTime = wm.UpdateTime
                })
                .ToListAsync();
        }

        public async Task<WebMenuDto> GetWebMenuById(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data != null)
            {
                return new WebMenuDto()
                {
                    Id = data.Id,
                    Title = data.Title,
                    Link = data.Link,
                    Icon = data.Icon,
                    ParentId = data.ParentId,
                    UpdateTime = data.UpdateTime
                };
            }

            return null;

        }
    }
}