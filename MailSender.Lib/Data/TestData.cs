using System.Collections.ObjectModel;
using MailSender.Lib.Entities;

namespace MailSender.Lib.Data
{
    public static class TestData
    {
        public static readonly ObservableCollection<Server> Servers = new ObservableCollection<Server>
        {
            new Server{Name = "Яндекс", Address = "smtp.yandex.ru", Port = 587, Login = "login", Password = "pass"},
            new Server{Name = "Mail.ru", Address = "smtp.mail.ru", Port = 587, Login = "login", Password = "pass"},
            new Server{Name = "GMail", Address = "smtp.gmail.com", Port = 587, Login = "login", Password = "pass"}
        };

        public static readonly ObservableCollection<Sender> Senders = new ObservableCollection<Sender>
        {
            new Sender{Name = "Иван", Address = "ivan@mail.ru"},
            new Sender{Name = "Сергей", Address = "sergei@yandex.ru"},
            new Sender{Name = "Мария", Address = "mariya@gmail.com"}
        };

        public static readonly ObservableCollection<Recipient> Recipients = new ObservableCollection<Recipient>
        {
            new Recipient{Name = "Иван", Address = "ivan@mail.ru"},
            new Recipient{Name = "Сергей", Address = "sergei@yandex.ru"},
            new Recipient{Name = "Мария", Address = "mariya@gmail.com"}
        };
    }
}

