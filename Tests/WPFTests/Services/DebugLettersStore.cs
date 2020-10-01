using System.Collections.Generic;
using MailSender.Lib.Data;
using MailSender.Lib.Entities;
using MailSender.MVVM;

namespace MailSender.Services
{
    public class DebugLettersStore : IStore<Letter>
    {
        public IEnumerable<Letter> Items => TestData.Letters;
    }
}
