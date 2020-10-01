using System;
using System.Collections.Generic;
using MailSender.Lib.Entities;
using MailSender.MVVM;

namespace MailSender.Services
{
    public class ServersManager : DataManager<Server>
    {
        private readonly IStore<Server> _serversStore;

        public ServersManager(IStore<Server> serversStore) => _serversStore = serversStore;

        public override IEnumerable<Server> Read() => _serversStore?.Items;

        public override void Add(Server item) => throw new NotImplementedException();

        public override void Update(Server item) => throw new NotImplementedException();

        public override void Delete(Server item) => throw new NotImplementedException();
    }
}
