using System.Collections.Generic;
using MailSender.Lib.Data;
using MailSender.Lib.Entities;
using MailSender.MVVM;

namespace MailSender.Services
{
    public class DebugServersStore : IStore<Server>
    {
        public IEnumerable<Server> Items => TestData.Servers;
    }
}
