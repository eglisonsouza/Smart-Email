using SmartEmail.Core.Models.Agrs;
using SmartEmail.Core.Services;

namespace SmartEmail.Infrastructure.Services
{
    public class SendEmailService(ISmtpService smtpService) : ISendEmailService
    {
        private readonly ISmtpService _smtpService = smtpService;

        public void SendEmail(EmailArgs emailArgs)
        {
            _smtpService.Send(emailArgs);
        }
    }
}
