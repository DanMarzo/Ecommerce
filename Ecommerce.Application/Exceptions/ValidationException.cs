using FluentValidation.Results;

namespace Ecommerce.Application.Exceptions;

public class ValidationException : ApplicationException
{
    public IDictionary<string, string[]> Errors { get; }
    public ValidationException() : base("Houve um ou mais erros de validacao") 
        => Errors = new Dictionary<string, string[]>();


    public ValidationException(IEnumerable<ValidationFailure> failures)
    {
        Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(fail => fail.Key, fail => fail.ToArray());
    }
}
