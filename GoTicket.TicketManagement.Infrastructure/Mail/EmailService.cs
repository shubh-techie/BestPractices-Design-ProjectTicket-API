using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoTicket.TicketManagement.Application.Contracts.Infrastructure;
using GoTicket.TicketManagement.Application.Model.Mail;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace GoTicket.TicketManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSetting { get; }
        public EmailService(IOptions<EmailSettings> mailSettings)
        {
            _emailSetting = mailSettings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSetting.FromAddress,
                Name = _emailSetting.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }
    }
}
