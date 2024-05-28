using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace VirtualPetAdoptionCenter.Core.Services
{
    public class EmailService : IEmailService
    {

        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string email, string text)
        {
            string smtpServer = _configuration["EmailSettings:SmtpServer"];
            int smtpPort = int.Parse(_configuration["EmailSettings:SmtpPort"]);
            string smtpUsername = _configuration["EmailSettings:SmtpUsername"];
            string smtpPassword = _configuration["EmailSettings:SmtpPassword"];

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpUsername),
                    Subject = "Notification",
                    Body = text,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(new MailAddress(email));
                smtpClient.Send(mailMessage);
            }
        }
    }
}

