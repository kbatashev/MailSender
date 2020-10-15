using System;
using System.Collections.Generic;
using MailSender.Entities;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public class MailsManager : IMailsManager
    {
        private readonly IMailsStore _lettersStore;

        public MailsManager(IMailsStore lettersStore) => _lettersStore = lettersStore;

        public IEnumerable<Mail> Read() => _lettersStore?.GetItems();

        public void Add(Mail item) => throw new NotImplementedException();

        public void Update(Mail item) => throw new NotImplementedException();

        public void Delete(Mail item) => throw new NotImplementedException();
    }
}
