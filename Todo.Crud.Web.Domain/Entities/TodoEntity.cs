namespace Todo.Crud.Web.Domain.Entities;

public class TodoEntity : BaseEntity
{
    public string? Description { get; set; }
    public bool Completed { get; set; }
}
