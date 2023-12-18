using SmartEmail.Core.Models.Agrs;
using SmartEmail.Core.Models.Ui.Settings;
using SmartEmail.Core.Services;
using System.Net;
using System.Net.Mail;

namespace SmartEmail.Infrastructure.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _email;

        public SmtpService(AppSettings appSettings)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _email = appSettings.SmtpService!.Email!;
            _smtpClient = BuildSmtpClient(appSettings.SmtpService!);
        }

        private static SmtpClient BuildSmtpClient(SmtpServiceSettings smtpServiceSettings)
        {
            return new()
            {
                Host = smtpServiceSettings.Host!,
                Port = smtpServiceSettings.Port,
                EnableSsl = smtpServiceSettings.EnableSsl,
                Credentials = new NetworkCredential(smtpServiceSettings.Email, smtpServiceSettings.Credential),
                UseDefaultCredentials = smtpServiceSettings.UseDefaultCredentials
            };
        }

        private MailMessage ToMailMessage(EmailArgs emailArgs)
        {
            return new MailMessage(from: _email, to: emailArgs.To, subject: emailArgs.Subject, body: emailArgs.Body)
            {
                IsBodyHtml = true
            };
        }

        public void Send(EmailArgs emailArgs)
        {
            _smtpClient.Send(ToMailMessage(emailArgs));
        }

    }
}
