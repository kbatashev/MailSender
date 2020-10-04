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

        public static readonly ObservableCollection<Letter> Letters = new ObservableCollection<Letter>()
        {
            new Letter {Id = 1, Subject = "Письмо 1", Body = "Проверка рассыльщика писем 1"},
            new Letter {Id = 2, Subject = "Письмо 2", Body = "Проверка рассыльщика писем 2"},
            new Letter {Id = 3, Subject = "Письмо 3", Body = "Проверка рассыльщика писем 3"},
        };
    }
}

