namespace Todo.Crud.Web.Domain.Interfaces;

public interface IUnitOfwork
{
    ITodoRepository TodoRepository { get; }

    Task CommitAsync();

    void Disponse();
}
