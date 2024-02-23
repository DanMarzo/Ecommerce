using Ecommerce.Application.Models.Email;

namespace Ecommerce.Application.Contracts.Infrastructure;

public interface IMailService
{
    Task<bool> SendEmail(EmailMessage email, string token);
}
