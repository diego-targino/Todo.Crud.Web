using Todo.Crud.Web.Domain.Entities;

namespace Todo.Crud.Web.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(int id);

    Task<TEntity> CreateAsync(TEntity entity);

    TEntity Update(TEntity entity);

    void Delete(TEntity entity);
}
