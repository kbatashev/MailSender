using System.Collections.Generic;
using MailSender.Lib.Data;
using MailSender.Lib.Entities;
using MailSender.MVVM;

namespace MailSender.Services
{
    public class DebugRecipientsStore : IStore<Recipient>
    {
        public IEnumerable<Recipient> Items => TestData.Recipients;
    }
}
