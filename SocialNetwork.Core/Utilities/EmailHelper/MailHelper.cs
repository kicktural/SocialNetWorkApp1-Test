using SocialNetwork.Core.Configration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Utilities.EmailHelper
{
    public class MailHelper : IMailHelper
    {
        public bool SendMail(string mailAddress, string token, bool bodyHtml)
        {
            var emailAddress = EmailConfigration.Email;
            var emailPassword = EmailConfigration.Password;

            string senderEmail = emailAddress;
            string senderPassword = emailPassword;

            //Create the SMTP client
            SmtpClient smtpClient = new(EmailConfigration.Smtp, EmailConfigration.Port)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, senderPassword)
            };

            try
            {
                // Create the email message
                MailMessage mailMessage = new()
                {
                    From = new MailAddress(senderEmail)
                };
                mailMessage.To.Add(mailAddress);
                mailMessage.Subject = $"Message from - {EmailConfigration.Email}";
                mailMessage.Body = $"<a href='https://localhost:7042/api/auth/verifypassword?email={mailAddress}&token={token}'>Tesdiq et</a>";
                // Specify that the body contains HTML
                mailMessage.IsBodyHtml = true;
                // Send the Email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
                return false;
            }


        }
    }
}
