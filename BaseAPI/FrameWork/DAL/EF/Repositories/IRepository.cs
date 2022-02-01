using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FrameWork.DAL.EF.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(long id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> GetAsync(
               Expression<Func<T, bool>> filter = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
               string includeProperties = "",
               int? skip = null, int? take = null);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteAsync(long id);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null);
    }
}
