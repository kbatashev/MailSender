using MailSender.Lib.Data;
using MailSender.Lib.Entities;
using MailSender.Interfaces;
using MailSender.Services;

namespace MailSender.Services
{
    public class DebugMailsStore : DebugStore<Mail>, IMailsStore
    {
        public DebugMailsStore() : base(TestData.Mails)
        {

        }

        public override void Update(int id, Mail mail)
        {
            var dbLetter = GetById(id);
            if (dbLetter == null)
                return;

            dbLetter.Subject = mail.Subject;
            dbLetter.Body = mail.Body;
        }
    }
}
