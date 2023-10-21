using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace FastFoodTotem.Api.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        var result = new ApiBaseResponse();

        try
        {
            await _next(context);
        }
        catch (ObjectNotFoundException)
        {
            response.StatusCode = (int)HttpStatusCode.NotFound;
            result.StatusCode = HttpStatusCode.NotFound;
            result.Errors = new List<KeyValuePair<string, List<string>>>()
            {
                new KeyValuePair<string, List<string>>("ObjectNotFoundException", new List<string>() { "Requested item has not been found" })
            };

            await response.WriteAsync(JsonSerializer.Serialize(result));
        }
        catch (Exception)
        {
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            result.StatusCode = HttpStatusCode.InternalServerError;
            result.Errors = new List<KeyValuePair<string, List<string>>>()
            {
                new KeyValuePair<string, List<string>>("InternalServerError", new List<string>() { "Internal server error" })
            };

            await response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}

