using Microsoft.Extensions.Configuration;
using PayloadPost.Models;
using PayloadPost.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace PayloadPost.Services
{
    public class SendgridEmailService : IEmailService
    {
        private IConfiguration _configuration;

        public SendgridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(EmailDetail emailDetail)
        {
            var apiKey = _configuration["Notification:Sendgrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(emailDetail.FromEmail, emailDetail.FromName);

            var to = new EmailAddress(emailDetail.ToEmail, emailDetail.ToName);

            if (String.IsNullOrWhiteSpace(emailDetail.HtmlContent))
            {
                emailDetail.HtmlContent = $"<p>{emailDetail.PlainTextContent}</p>";
            }

            var msg = MailHelper.CreateSingleEmail(from, to, emailDetail.Subject, emailDetail.PlainTextContent, emailDetail.HtmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
