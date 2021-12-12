using BlogSystem.Dtos;
using BlogSystem.IBLL;
using BlogSystem.IDAL;
using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.BLL
{
    public class CategoryBll : ICategoryBll
    {

        private ICategoryDal _dal;

        public CategoryBll(ICategoryDal dal)
        {
            _dal = dal;
        }


        public async Task<int> AddCategoryAsync(string title, string detail)
        {
            return await _dal.AddAsync(new Category 
            {
                Title = title,
                Details = detail
            });
        }

        public async Task<int> DeleteCategoryAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;
            return await _dal.DeleteAsync(data);
        }

        public async Task<int> EditCategoryAsync(Guid id, string title, string detail)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
                return -1;

            data.Title = title;
            data.Details = detail;
            data.UpdateTime = DateTime.Now;
            return await _dal.EditAsync(data);

        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _dal.Query()
                 .OrderByDescending(c => c.UpdateTime)
                 .Select(c => new CategoryDto
                 {
                     Id = c.Id,
                     Title = c.Title,
                     Details = c.Details,
                     UpdateTime =c.UpdateTime

                 }).ToListAsync();
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);

            return data == null ? null : new CategoryDto 
            {
                Id = data.Id,
                Title = data.Title,
                Details = data.Details,
                UpdateTime = data.UpdateTime
            };
        }

        public async Task<List<CategoryDto>> GetDataByTitleAsync(string title)
        {
            return await _dal.Query(c => c.Title.Contains(title))
                 .OrderByDescending(c => c.UpdateTime)
                 .Select(c => new CategoryDto
                 {
                     Id = c.Id,
                     Title = c.Title,
                     Details = c.Details,
                     UpdateTime = c.UpdateTime

                 }).ToListAsync();
        }

        public async Task<List<CategoryDto>> GetDataByTop4()
        {
            return await _dal.Query()
                 .OrderByDescending(c => c.UpdateTime)
                 .Select(c => new CategoryDto
                 {
                     Id = c.Id,
                     Title = c.Title,
                     Details = c.Details,
                     UpdateTime = c.UpdateTime

                 }).Take(4).ToListAsync();
        }

        public async Task<bool> IsExistsAsync(string title)
        {
            var data = _dal.Query(c => c.Title.Equals(title));

            return !(await data.AnyAsync()); // 当我们找到元素了,返回false,告诉前面这个类别名称是不可用的
        }
    }
}
