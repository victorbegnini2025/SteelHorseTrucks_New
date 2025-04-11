using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace SteelHorseTrucks.Services
{
    public class EmailSender
    {
        private readonly string _apiKey;
        private readonly string _fromEmail;

        public EmailSender(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
            _fromEmail = configuration["SendGrid:FromEmail"];
            Console.WriteLine("🔐 SendGrid API Key loaded? " + (_apiKey != null ? "YES" : "NO"));
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_fromEmail, "SteelHorse MFA");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);

            Console.WriteLine($"[SendGrid] Status: {response.StatusCode}");
            if ((int)response.StatusCode >= 400)
            {
                var body = await response.Body.ReadAsStringAsync();
                Console.WriteLine("[SendGrid] ERROR RESPONSE:\n" + body);
            }
        }
    }
}
