using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace MailhogSample.API.Services
{
    public class EmailService
    {
        public EmailService() { }

        public async Task SendEmail(string subject, string body, string from, List<string> to, List<string> bcc, string emailDisplayName)
        {
            try
            {
                using var smtpClient = new SmtpClient("mailhog_server", 1025);
                
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(from, emailDisplayName),
                    Subject = subject,
                    Body = body
                };

                to.ForEach(mailMessage.To.Add);
                bcc.ForEach(mailMessage.Bcc.Add);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch
            {
                throw;
            }
        }

    }
}
