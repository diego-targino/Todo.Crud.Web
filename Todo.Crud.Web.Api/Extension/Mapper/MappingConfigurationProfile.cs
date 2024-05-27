using AutoMapper;
using Todo.Crud.Web.Api.Model;
using Todo.Crud.Web.Domain.DTOs.Request;
using Todo.Crud.Web.Domain.DTOs.Response;
using Todo.Crud.Web.Domain.Entities;

namespace Todo.Crud.Web.Api.Extension.Mapper;

public class MappingConfigurationProfile : Profile
{
    public MappingConfigurationProfile()
    {
        CreateMap<CreateTodoModel, CreateTodoDTO>();

        CreateMap<EditTodoModel, EditTodoDTO>()
            .ForMember(dto => dto.Completed, opt => opt.MapFrom(model => model.Body!.Completed))
            .ForMember(dto => dto.Description, opt => opt.MapFrom(model => model.Body!.Description));

        CreateMap<CreateTodoDTO, TodoEntity>();

        CreateMap<TodoEntity, TodoResponseDTO>();

        CreateMap<TodoEntity, CreateTodoResponseDTO>();

        CreateMap<TodoEntity, EditTodoResponseDTO>();
    }
}
