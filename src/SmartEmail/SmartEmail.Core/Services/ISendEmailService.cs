using SmartEmail.Core.Models.Agrs;

namespace SmartEmail.Core.Services
{
    public interface ISendEmailService
    {
        void SendEmail(EmailArgs emailArgs);
    }
}
