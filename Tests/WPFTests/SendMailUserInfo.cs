using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace MailSender
{
    public static class SendMailUserInfo
    {
        private static string emailFrom = "user@yandex.ru";
        private static string emailTo = "user@mail.ru";
        private static string emailSubject = "Тестовый заголовок";
        private static string emailBody = "Тестовое наполнение";
        private static string server = "smtp.yandex.ru";
        private static int port = 25;
        
        
        public static string EmailFrom { get => emailFrom; set => emailFrom = value; }
        public static string EmailTo { get => emailTo; set => emailTo = value; }
        public static string EmailSubject { get => emailSubject; set => emailSubject = value; }
        public static string EmailBody { get => emailBody; set => emailBody = value; }
        public static string Server { get => server; set => server = value; }
        public static int Port { get => port; set => port = value; }

    }
}
