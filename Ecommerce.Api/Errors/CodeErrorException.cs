using System.Text.Json.Serialization;

namespace Ecommerce.Api.Errors;

public class CodeErrorException : CodeErrorResponse
{
    public CodeErrorException(
        int statusCode, string[]? message = null, 
        string? details = null) 
        : base(statusCode, message)
    {
        Details = details;
    }

    [JsonPropertyName("details")]
    public string? Details { get; set; }

}
