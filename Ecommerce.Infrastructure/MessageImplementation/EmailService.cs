using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.Email;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Ecommerce.Infrastructure.MessageImplementation;

public class EmailService : IEmailService
{
    public EmailSettings _emailSettings { get; }
    public ILogger<EmailService> _logger { get; }
    public EmailService(IOptions<EmailSettings> emailSettings, ILogger<EmailService> logger)
    {
        _emailSettings = emailSettings.Value;
        _logger = logger;   
    }
    public async Task<bool> SendEmail(EmailMessage email, string token)
    {
        try
        {
            SendGridClient client = new(_emailSettings.Key);
            EmailAddress from = new(_emailSettings.Email);
            string? subject = email.Subject;
            var to = new EmailAddress(email.To, email.To);
            var plainTextContent = email.Body;
            var htmlContent = $"{email.Body} {_emailSettings.BaseUriClient}/password/reset/{token}";
            var msg = MailHelper.CreateSingleEmail(from, to,subject, plainTextContent, htmlContent);
            Response response = await client.SendEmailAsync(msg);
            return response.IsSuccessStatusCode;
        }
        catch (Exception)
        {
            _logger.LogError("O email não pode ser enviado.");
            return false;
        }
    }
}
