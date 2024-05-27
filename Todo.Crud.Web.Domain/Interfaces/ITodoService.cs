using Todo.Crud.Web.Domain.DTOs.Request;
using Todo.Crud.Web.Domain.DTOs.Response;

namespace Todo.Crud.Web.Domain.Interfaces;

public interface ITodoService
{
    Task<IEnumerable<TodoResponseDTO>> GetAllAsync();

    Task<TodoResponseDTO> GetByIdAsync(int id);

    Task<CreateTodoResponseDTO> CreateAsync(CreateTodoDTO createTodoDTO);

    Task<EditTodoResponseDTO> EditAsync(EditTodoDTO editTodoDTO);

    Task DeleteAsync(int id);
}
