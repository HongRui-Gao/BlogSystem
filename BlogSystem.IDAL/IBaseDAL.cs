using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlogSystem.Models;

namespace BlogSystem.IDAL
{
    public interface IBaseDAL<T> : IDisposable where T:BaseEntity,new()
    {
        Task<int> AddAsync(T model);

        Task<int> EditAsync(T model);

        Task<int> DeleteAsync(T model);

        IQueryable<T> Query();

        IQueryable<T> Query(Expression<Func<T,bool>> whereLambda);

        Task<T> QueryAsync(Guid id);

        Task<bool> IsExistsAsync(Expression<Func<T, bool>> whereLambda);

        Task<int> GetCountsAsync(Expression<Func<T,bool>> whereLambda);

        IQueryable<T> QueryByPage(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLamba, bool isAsc);
    }
}