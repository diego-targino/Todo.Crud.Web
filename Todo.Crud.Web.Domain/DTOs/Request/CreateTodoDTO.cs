namespace Todo.Crud.Web.Domain.DTOs.Request;

public record CreateTodoDTO(
    string? Description,
    bool? Completed
);

