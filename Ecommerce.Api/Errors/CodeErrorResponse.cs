using System.Text.Json.Serialization;

namespace Ecommerce.Api.Errors;

public class CodeErrorResponse
{
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }
    [JsonPropertyName("message")]
    public string[]? Message { get; set; }

    public CodeErrorResponse(int statusCode, string[]? message = null)
    {
        StatusCode = statusCode;
        if (message is null)
        {
            Message = [];
            var text = GetDefaultMessageStatusCode(statusCode);
            Message[0] = text;
        }
        else
        {
            Message = message;
        }
    }

    private string GetDefaultMessageStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "A requisicao enviada contem erros",
            401 => "Voce nao possui autorizacao para usar este recurso",
            404 => "O recurso nao foi localizado",
            500 => "Ocorreram erros no servidor",
            _ => string.Empty,
        };
    }


}
