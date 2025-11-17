using FiapCloud.Users.App.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace FiapCloud.Users.Api.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning(ex, "Recurso não encontrado: {Message}", ex.Message);
            await WriteErrorResponseAsync(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (ValidationException ex)
        {
            _logger.LogWarning(ex, "Erro de validação: {Message}", ex.Message);
            await WriteErrorResponseAsync(context, HttpStatusCode.UnprocessableEntity, ex.Message);
        }
        catch (AppException ex)
        {
            _logger.LogError(ex, "Erro de aplicação: {Message}", ex.Message);
            await WriteErrorResponseAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro inesperado");
            await WriteErrorResponseAsync(context, HttpStatusCode.InternalServerError, "Erro interno no servidor");
        }
    }

    private static async Task WriteErrorResponseAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json";

        var errorResponse = new
        {
            success = false,
            status = (int)statusCode,
            error = message
        };

        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, options));
    }
}
