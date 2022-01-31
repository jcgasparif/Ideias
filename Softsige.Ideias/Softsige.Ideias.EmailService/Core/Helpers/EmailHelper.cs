using System;
using System.Net;
using System.Net.Mail;

namespace Softsige.Ideias.EmailService.Core.Helpers
{
    public class EmailHelper
    {
        public static bool SendEmail(string userEmail, string subject, string body)
        {

            var mailMessage = new MailMessage
            {
                From = new MailAddress("softsige@softsige.com.br")
            };
            mailMessage.To.Add(new MailAddress(userEmail));
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = body;

            var client = new SmtpClient
            {
                Credentials = new NetworkCredential("softsige@softsige.com.br", "#Ci1468&!"),
                Host = "softsige.com.br",
                Port = 587
            };

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}