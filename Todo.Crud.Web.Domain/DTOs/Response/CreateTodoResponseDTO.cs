namespace Todo.Crud.Web.Domain.DTOs.Response;

public record CreateTodoResponseDTO
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public bool? Completed { get; set; }

    public DateTime? CreatedAt { get; set; }
}
