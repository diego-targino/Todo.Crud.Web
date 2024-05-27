using Todo.Crud.Web.Domain.Entities;
using Todo.Crud.Web.Domain.Interfaces;
using Todo.Crud.Web.Infrastructure.Context;

namespace Todo.Crud.Web.Infrastructure.Repositories;

public class TodoRepository : BaseRepository<TodoEntity>, ITodoRepository
{
    public TodoRepository(AppDbContext appDbContext) : base(appDbContext) { }
}
