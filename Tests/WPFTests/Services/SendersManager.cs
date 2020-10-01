using System;
using System.Collections.Generic;
using MailSender.Lib.Entities;
using MailSender.MVVM;

namespace MailSender.Services
{
    public class SendersManager : DataManager<Sender>
    {
        private readonly IStore<Sender> _sendersStore;

        public SendersManager(IStore<Sender> sendersStore) => _sendersStore = sendersStore;

        public override IEnumerable<Sender> Read() => _sendersStore?.Items;

        public override void Add(Sender item) => throw new NotImplementedException();

        public override void Update(Sender item) => throw new NotImplementedException();

        public override void Delete(Sender item) => throw new NotImplementedException();
    }
}
