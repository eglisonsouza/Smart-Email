using SmartEmail.Core.Models.Agrs;

namespace SmartEmail.Core.Services
{
    public interface ISmtpService
    {
        void Send(EmailArgs emailArgs);
    }
}
