using AutoMapper;
using Todo.Crud.Web.Domain.CustomExceptions;
using Todo.Crud.Web.Domain.DTOs.Request;
using Todo.Crud.Web.Domain.DTOs.Response;
using Todo.Crud.Web.Domain.Entities;
using Todo.Crud.Web.Domain.Interfaces;

namespace Todo.Crud.Web.Application.Services;

public class TodoService : ITodoService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfwork _unitOfwork;

    public TodoService(IUnitOfwork unitOfwork, IMapper mapper)
    {
        _unitOfwork = unitOfwork;
        _mapper = mapper;
    }

    public async Task<CreateTodoResponseDTO> CreateAsync(CreateTodoDTO createTodoDTO)
    {
        try
        {
            TodoEntity todo = _mapper.Map<TodoEntity>(createTodoDTO);

            todo = await _unitOfwork.TodoRepository.CreateAsync(todo);

            await _unitOfwork.CommitAsync();

            return _mapper.Map<CreateTodoResponseDTO>(todo);
        }
        catch
        {
            _unitOfwork.Disponse();
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            TodoEntity? todo = await _unitOfwork.TodoRepository.GetByIdAsync(id);

            if (todo is null) throw new NotFoundException("Tarefa não encontrada");

            _unitOfwork.TodoRepository.Delete(todo);

            await _unitOfwork.CommitAsync();
        }
        catch
        {
            _unitOfwork.Disponse();
            throw;
        }
    }

    public async Task<EditTodoResponseDTO> EditAsync(EditTodoDTO editTodoDTO)
    {
        try
        {
            TodoEntity? todo = await _unitOfwork.TodoRepository.GetByIdAsync(editTodoDTO.Id);

            if (todo is null) throw new NotFoundException("Tarefa não encontrada");

            todo.Completed = editTodoDTO.Completed!.Value;
            todo.Description = editTodoDTO.Description;

            todo = _unitOfwork.TodoRepository.Update(todo);

            await _unitOfwork.CommitAsync();

            return _mapper.Map<EditTodoResponseDTO>(todo);
        }
        catch
        {
            _unitOfwork.Disponse();
            throw;
        }
    }

    public async Task<IEnumerable<TodoResponseDTO>> GetAllAsync()
    {
        IEnumerable<TodoEntity> todos = await _unitOfwork.TodoRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<TodoResponseDTO>>(todos);
    }

    public async Task<TodoResponseDTO> GetByIdAsync(int id)
    {
        TodoEntity? todo = await _unitOfwork.TodoRepository.GetByIdAsync(id);

        if (todo is null) throw new NotFoundException("Tarefa não encontrada");

        return _mapper.Map<TodoResponseDTO>(todo);
    }
}
