using BlazorDemo.Data.Models;
using BlazorServerDemo2024.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlazorDemo.Data;

public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
{
    private readonly DbContext dbContext;
    private DbSet<TEntity> items;

    public GenericRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
        items = dbContext.Set<TEntity>();
    }

    public async Task<TKey> AddAsync(TEntity entity)
    {
        items.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = new TEntity() { Id = id};
        items.Remove(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;

    }

    public IQueryable<TEntity> GetAll()
    {
        return items.AsNoTracking();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await items.Where(filter).ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var entityDb = await items.FindAsync(id);
        if (entityDb is not null)
        {
            dbContext.Entry(entityDb).State = EntityState.Detached;
            return entityDb;
        }
        return null;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        items.Update(entity);
        await dbContext.SaveChangesAsync();
        dbContext.Entry(entity).State = EntityState.Detached;
    }
}
