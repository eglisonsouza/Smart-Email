namespace SmartEmail.Core.Models.Ui.Settings
{
    public class AppSettings
    {
        public SmtpServiceSettings? SmtpService { get; set; }
        public RabbitMqSettings? RabbitMq { get; set; }
    }

    public class RabbitMqSettings
    {
        public string? Host { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? Uri { get; set; }
    }

    public class SmtpServiceSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string? Email { get; set; }
        public string? Credential { get; set; }
        public bool UseDefaultCredentials { get; set; }
    }
}
