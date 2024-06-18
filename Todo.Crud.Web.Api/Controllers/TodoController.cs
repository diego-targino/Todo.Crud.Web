using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Crud.Web.Api.Model;
using Todo.Crud.Web.Domain.DTOs.Request;
using Todo.Crud.Web.Domain.DTOs.Response;
using Todo.Crud.Web.Domain.Interfaces;

namespace Todo.Crud.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService, IMapper mapper)
    {
        _todoService = todoService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        IEnumerable<TodoResponseDTO> todos = await _todoService.GetAllAsync();

        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        TodoResponseDTO todoResponseDTO = await _todoService.GetByIdAsync(id);

        return Ok(todoResponseDTO);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateTodoModel createTodoModel)
    {
        CreateTodoDTO createTodoDTO = _mapper.Map<CreateTodoDTO>(createTodoModel);

        CreateTodoResponseDTO createTodoResponseDTO = await _todoService.CreateAsync(createTodoDTO);

        return Created(new Uri($"https://localhost:7149/api/Todo/{createTodoResponseDTO.Id}"), createTodoResponseDTO);
    }


    [HttpPut("{Id}")]
    public async Task<IActionResult> Put(EditTodoModel editTodoModel)
    {
        EditTodoDTO editTodoDTO = _mapper.Map<EditTodoDTO>(editTodoModel);

        EditTodoResponseDTO editTodoResponseDTO = await _todoService.EditAsync(editTodoDTO);

        return Ok(editTodoResponseDTO);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _todoService.DeleteAsync(id);

        return Ok("Tarefa excluída com sucesso");
    }
}
