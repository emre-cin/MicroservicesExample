using Example.Services.Catalog.Domain.Models.Entities.Base;
using System.Linq.Expressions;

namespace Example.Services.Catalog.Core.Repository
{
    public interface IRepository<T> where T : class, IEntity, new() 
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(string id);
        Task<T> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<T> UpdateAsync(string id, T entity);
        Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteAsync(string id);
        Task<T> DeleteAsync(Expression<Func<T, bool>> predicate);
        void DeleteAllAsync(Expression<Func<T, bool>> filter);
    }
}
