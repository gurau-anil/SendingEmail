using System;
using System.Net;
using System.Net.Mail;

namespace SendingEmail
{
    class EmailSender
    {
        public void SendEmail(Mail mail)
        {
            MailMessage mailMessage = new MailMessage("xxxxx@gmail.com", mail.To.ToString())
            {
                Subject = mail.Subject,
                Body = mail.Body,
                IsBodyHtml = false
            };


            SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false
            };


            NetworkCredential network = new NetworkCredential("xxxxx@gmail.com", "*********");
            smtpClient.Credentials = network;

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine($"Email is successfully delivered to {mail.To}");
            }
            catch (Exception)
            {
                Console.WriteLine("Sending Email Failed.");
            }
        }
    }
}
