using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlogSystem.IDAL;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class BaseDAL<T> : IBaseDAL<T> where T:BaseEntity,new()
    {
        //1. 需要先找到Model层数据库上下文
        private BlogSystemContext _db;

        public BaseDAL(BlogSystemContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task<int> AddAsync(T model)
        {
            _db.Entry<T>(model).State = EntityState.Added;
            return await _db.SaveChangesAsync();
        }

        public async Task<int> EditAsync(T model)
        {
            _db.Entry<T>(model).State = EntityState.Modified;
            return await _db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T model)
        {
            _db.Entry<T>(model).State = EntityState.Deleted;
            return await _db.SaveChangesAsync();
        }

        public IQueryable<T> Query()
        {
            return _db.Set<T>();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> whereLambda)
        {
            return _db.Set<T>().Where(whereLambda);
        }

        public async Task<T> QueryAsync(Guid id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExistsAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _db.Set<T>().Where(whereLambda).AnyAsync();
        }

        public async Task<int> GetCountsAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _db.Set<T>().Where(whereLambda).CountAsync();
        }

        public IQueryable<T> QueryByPage(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLamba, bool isAsc)
        {
            if (isAsc)
            {
                return _db.Set<T>()
                    .Where(whereLamba)
                    .OrderBy(t => t.UpdateTime)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize);
            }
            else
            {
                return _db.Set<T>()
                    .Where(whereLamba)
                    .OrderByDescending(t => t.UpdateTime)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize);
            }
        }
    }
}