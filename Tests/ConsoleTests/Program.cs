using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var to = new MailAddress("kbatashev@mail.ru", "Кирилл");
            var from = new MailAddress("kbatashev@yandex.ru", "Кирилл");

            var message = new MailMessage(from, to);

            message.Subject = "Тестовое письмо от " + DateTime.Now;
            message.Body = "Тестовый текст" + DateTime.Now;

            var client = new SmtpClient("smtp.yandex.ru", 25);

            client.Credentials = new NetworkCredential
            {
                UserName = "",
                Password = ""
            };

            client.Send(message);

            Console.WriteLine("Hello World!");
        }
    }
}
