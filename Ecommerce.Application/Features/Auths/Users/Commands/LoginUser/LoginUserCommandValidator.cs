using FluentValidation;

namespace Ecommerce.Application.Features.Auths.Users.Commands.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("O Email no puede ser nulo");
        RuleFor(x => x.Password).NotEmpty().WithMessage("O Password no puede ser nulo");
    }
}
