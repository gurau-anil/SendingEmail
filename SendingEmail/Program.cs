using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SendingEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex emailRegex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");

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
                else if(!emailRegex.IsMatch(mail.To))
                {
                    Console.WriteLine("Invalid email address.");
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
}
