using Todo.Crud.Web.Domain.Interfaces;
using Todo.Crud.Web.Infrastructure.Context;

namespace Todo.Crud.Web.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfwork
{
    private readonly AppDbContext _appDbContext;
    private ITodoRepository? _todoRepository;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public ITodoRepository TodoRepository
    {
        get
        {
            _todoRepository ??= new TodoRepository(_appDbContext);

            return _todoRepository;
        }
    }

    public async Task CommitAsync()
    {
        await _appDbContext.SaveChangesAsync();
    }

    public void Disponse()
    {
        _appDbContext.Dispose();
    }
}
