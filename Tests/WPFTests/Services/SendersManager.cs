using System;
using System.Collections.Generic;
using MailSender.Lib.Entities;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public class SendersManager : ISendersManager
    {
        private readonly IStore<Sender> _sendersStore;

        public SendersManager(IStore<Sender> sendersStore) => _sendersStore = sendersStore;

        public IEnumerable<Sender> Read() => _sendersStore?.GetItems();

        public void Add(Sender item) => throw new NotImplementedException();

        public void Update(Sender item) => throw new NotImplementedException();

        public void Delete(Sender item) => throw new NotImplementedException();
    }
}
