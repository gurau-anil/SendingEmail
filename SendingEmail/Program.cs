using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
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

                if(String.IsNullOrWhiteSpace(mail.To))
                {
                    Console.WriteLine("You must enter an email address.");
                    continue;
                }
                else
                {
                    EmailSender mailSender = new EmailSender();
                    mailSender.SendEmail(mail);
                }

                Console.WriteLine("Want to send Email Again?");
                Console.WriteLine("Press 'Y' to yes and 'N' to no.");
                int choice=Console.Read();
                if(choice == (int)'y' || choice == (int)'Y')
                {
                    continue;
                }
                else if(choice == (int)'n' || choice == (int)'N')
                {
                    Console.WriteLine("Exiting the program....");
                    Thread.Sleep(3000);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong choice.");
                    Console.WriteLine("Exiting the program....");
                    Thread.Sleep(2000);
                    Environment.Exit(-1);
                }
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
