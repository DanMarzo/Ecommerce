using Ecommerce.Api.Errors;
using Ecommerce.Application.Exceptions;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Ecommerce.Api.MIddlewares;

public class ExceptionMiddleware
{
    //Request Delegate é o Request que esta sendo enviando pela cliente
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
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
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (ex)
            {
                case NotFoundException:
                    statusCode =
                        (int)HttpStatusCode.NotFound;
                    break;
                case FluentValidation.ValidationException validateException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    var errors = validateException.Errors.Select(err => err.ErrorMessage).ToArray();
                    var validationJson = JsonSerializer.Serialize(errors);
                    result = JsonSerializer.Serialize(new CodeErrorException(statusCode, errors, validationJson));
                    break;
                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            if (string.IsNullOrEmpty(result))
            {
                result = JsonSerializer.Serialize(
                    new CodeErrorException(statusCode, [ex.Message], ex.StackTrace)
                    );
            }
            
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(result);

        }
    }
}
