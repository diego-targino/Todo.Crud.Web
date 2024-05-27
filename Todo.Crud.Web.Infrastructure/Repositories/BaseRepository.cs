using Microsoft.EntityFrameworkCore;
using Todo.Crud.Web.Domain.Entities;
using Todo.Crud.Web.Domain.Interfaces;
using Todo.Crud.Web.Infrastructure.Context;

namespace Todo.Crud.Web.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _appDbContext;

    public BaseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        entity.CreatedAt = DateTime.Now;

        await _appDbContext.Set<TEntity>().AddAsync(entity);

        return entity;
    }

    public void Delete(TEntity entity)
    {
        _appDbContext.Set<TEntity>().Remove(entity);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _appDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _appDbContext.Set<TEntity>().FindAsync(id);
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdatedAt = DateTime.Now;

        _appDbContext.Set<TEntity>().Update(entity);

        return entity;
    }
}
