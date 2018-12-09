using System.Net;
using cancer_isp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace cancer_isp.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly IConfiguration _configuration;

        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpFrom;
        private readonly string _smtpPassword;

		public SmtpService(IConfiguration configuration)
        {
            _configuration = configuration;

            _smtpHost = _configuration.GetValue<string>("Smtp:Host");
            _smtpPort = _configuration.GetValue<int>("Smtp:Port");
            _smtpFrom = _configuration.GetValue<string>("Smtp:From");
            _smtpPassword = _configuration.GetValue<string>("Smtp:Password");
        }

        public void SendPasswordReminder(string email)
        {
            var client = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Port = _smtpPort,
                Host = _smtpHost,
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = _smtpFrom,
                    Password = _smtpPassword
                }
            };

            var mail = new MailMessage
            {
                Subject = "CancerISP password reminder",
                Body = "Your password is ",
                From = new MailAddress(_smtpFrom),
                To = {email}
            };

            client.Send(mail);
        }
    }
}