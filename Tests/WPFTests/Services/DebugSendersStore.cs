using System.Collections.Generic;
using MailSender.Lib.Data;
using MailSender.Lib.Entities;
using MailSender.MVVM;

namespace MailSender.Services
{
    public class DebugSendersStore : IStore<Sender>
    {
        public IEnumerable<Sender> Items => TestData.Senders;
    }
}
