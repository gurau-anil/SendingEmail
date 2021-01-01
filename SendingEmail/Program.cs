using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendingEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Mail mail = new Mail();
                Console.WriteLine("Receiver's Email :");
                mail.To = Console.ReadLine();

                Console.WriteLine("Subject :");
                mail.Subject = Console.ReadLine();

                Console.WriteLine("Body :");
                mail.Body = Console.ReadLine();


                EmailSender mailSender = new EmailSender();
                mailSender.SendEmail(mail);

                Console.ReadLine();
            }
        }
    }
    class Mail
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    class EmailSender
    {
        public void SendEmail(Mail mail)
        {
            MailMessage mailMessage = new MailMessage("gurau.aneel@gmail.com", mail.To.ToString())
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


            NetworkCredential network = new NetworkCredential("gurau.aneel@gmail.com", "xr11060720");
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
