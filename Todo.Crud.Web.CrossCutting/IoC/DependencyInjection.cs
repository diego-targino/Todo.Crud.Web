using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Crud.Web.Application.Services;
using Todo.Crud.Web.Domain.Interfaces;
using Todo.Crud.Web.Infrastructure.Context;
using Todo.Crud.Web.Infrastructure.Middlewares;
using Todo.Crud.Web.Infrastructure.Repositories;

namespace Todo.Crud.Web.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructureDI(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TodoDatabase"));

        services.AddScoped<IUnitOfwork, UnitOfWork>();

        return services;
    }

    public static IServiceCollection AddApplicationDI(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();

        return services;
    }

    public static IApplicationBuilder UseApplicationMiddlewares(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<ExceptionMiddleware>();

        return builder;
    }
}
