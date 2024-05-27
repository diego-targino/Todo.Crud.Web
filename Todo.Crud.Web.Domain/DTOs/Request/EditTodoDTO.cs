namespace Todo.Crud.Web.Domain.DTOs.Request;

public class EditTodoDTO
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public bool? Completed { get; set; }
}
