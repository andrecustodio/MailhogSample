namespace MailhogSample.API.Controllers.Models
{
    public class EmailSenderModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public List<string> To { get; set; }
        public List<string>? Bcc { get; set; } = new List<string>();
        public string EmailDisplayName { get; set; }
    }
}
