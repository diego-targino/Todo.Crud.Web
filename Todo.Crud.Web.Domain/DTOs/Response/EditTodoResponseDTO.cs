namespace Todo.Crud.Web.Domain.DTOs.Response;

public class EditTodoResponseDTO
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public bool? Completed { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}