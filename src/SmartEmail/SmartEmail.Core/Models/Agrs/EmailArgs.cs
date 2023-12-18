namespace SmartEmail.Core.Models.Agrs
{
    public class EmailArgs(string to, string subject, string body)
    {
        public string To { get; set; } = to;
        public string Subject { get; set; } = subject;
        public string Body { get; set; } = body;
    }
}
