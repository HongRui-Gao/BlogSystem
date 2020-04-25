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
    public class SystemMenuBll : ISystemMenuBll
    {
        private ISystemMenuDal _dal;

        public SystemMenuBll(ISystemMenuDal dal)
        {
            _dal = dal;
        }
        public async Task<int> AddSystemMenuAsync(string title, string link, string icon, Guid parentId)
        {
            return await _dal.AddAsync(new SystemMenu()
            {
                Title = title,
                Link = link,
                Icon = icon,
                ParentId = parentId
            });
        }

        public async Task<int> EditSystemMenuAsync(Guid id, string title, string link, string icon, Guid parentId)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -2;
            data.ParentId = parentId;
            data.Link = link;
            data.Icon = icon;
            data.Title = title;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);
        }

        public async Task<int> DeleteSystemMenuAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -2;
            return await _dal.DeleteAsync(data);
        }

        public async Task<List<SystemMenuDto>> GetSystemMenuListByTitle(string title)
        {
            return await _dal.Query(sm => sm.Title.Contains(title))
                             .Select(sm=>new SystemMenuDto()
                             {
                                 Id= sm.Id,
                                 Title = sm.Title,
                                 Link = sm.Link,
                                 Icon =sm.Icon,
                                 ParentId = sm.ParentId,
                                 UpdateTime = sm.UpdateTime
                             })
                             .ToListAsync();
        }

        public async Task<List<SystemMenuDto>> GetSystemMenuListByParentId(Guid pid)
        {
            return await _dal.Query(sm => sm.ParentId == pid)
                .Select(sm => new SystemMenuDto()
                {
                    Id = sm.Id,
                    Title = sm.Title,
                    Link = sm.Link,
                    Icon = sm.Icon,
                    ParentId = sm.ParentId,
                    UpdateTime = sm.UpdateTime
                })
                .ToListAsync();
        }

        public async Task<SystemMenuDto> GetSystemMenu(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return null;
            return new SystemMenuDto()
            {
                Id = data.Id,
                Title = data.Title,
                Link = data.Link,
                Icon = data.Icon,
                ParentId = data.ParentId,
                UpdateTime = data.UpdateTime
            };
        }
    }
}