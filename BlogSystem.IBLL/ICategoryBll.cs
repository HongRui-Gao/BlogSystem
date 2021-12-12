using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Dtos;
namespace BlogSystem.IBLL
{
    public interface ICategoryBll
    {

        Task<int> AddCategoryAsync(string title, string detail);

        Task<int> EditCategoryAsync(Guid id, string title, string detail);

        Task<int> DeleteCategoryAsync(Guid id);


        Task<List<CategoryDto>> GetAllAsync();


        Task<List<CategoryDto>> GetDataByTitleAsync(string title);

        Task<CategoryDto> GetCategoryByIdAsync(Guid id);

        Task<bool> IsExistsAsync(string title);

        Task<List<CategoryDto>> GetDataByTop4();


    }
}
