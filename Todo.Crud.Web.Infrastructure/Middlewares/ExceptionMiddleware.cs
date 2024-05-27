using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Todo.Crud.Web.Domain.CustomExceptions;

namespace Todo.Crud.Web.Infrastructure.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ExceptionHandler(ex, context);
        }
    }

    public async Task ExceptionHandler(Exception exception, HttpContext context)
    {
        context.Response.Headers.Add("Content-Type", "application/json");

        switch (exception)
        {
            case NotFoundException:
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(JsonSerializer.Serialize(
                    new 
                    { 
                        exception.Message 
                    })
                );
                break;
            default:
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(JsonSerializer.Serialize(
                    new
                    {
                        Message = "Houve um erro no sistema, tente novamente mais tarde."
                    })
                );
                break;
        }
    }
}
