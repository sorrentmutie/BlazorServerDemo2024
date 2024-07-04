using System.Linq.Expressions;

namespace BlazorServerDemo2024.Core;

public interface IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
{
    IQueryable<TEntity> GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<TKey> AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TKey id);
}
