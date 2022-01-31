using System;
using System.Net;
using System.Net.Mail;

namespace Softsige.Ideias.App.Core.Helpers
{
    public class EmailHelper
    {
        public bool SendEmail(string userEmail, string confirmationLink)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("softsige@softsige.com.br")
            };

            mailMessage.To.Add(new MailAddress(userEmail));
            mailMessage.Subject = "Confirme seu e-mail";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = confirmationLink;

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
                // log exception
            }

            return false;
        }

        public bool SendEmailPasswordReset(string userEmail, string link)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("softsige@softsige.com.br")
            };

            mailMessage.To.Add(new MailAddress(userEmail));
            mailMessage.Subject = "Reset de Senha";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = link;

            var client = new SmtpClient
            {
                Credentials = new NetworkCredential("softsige@softsige.com.br", "#Ci1468&!"),
                Host = "softsige.com.br",
                Port = 587,
                EnableSsl = true
            };

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                // log exception
            }

            return false;
        }

        public bool SendEmailTwoFactorCode(string userEmail, string code)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("softsige@softsige.com.br")
            };

            mailMessage.To.Add(new MailAddress(userEmail));
            mailMessage.Subject = "Two Factor Code";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = code;

            var client = new SmtpClient
            {
                Credentials = new NetworkCredential("softsige@softsige.com.br", "#Ci1468&!"),
                Host = "softsige.com.br",
                Port = 465
            };

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                // log exception
            }

            return false;
        }
    }
}