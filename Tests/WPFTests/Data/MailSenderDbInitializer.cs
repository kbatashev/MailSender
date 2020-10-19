using System.Data.Entity;
using MailSender.Lib.Entities;

namespace MailSender.Data
{
    public class MailSenderDbInitializer : DropCreateDatabaseAlways<MailSenderDbContext>
    {
        protected override void Seed(MailSenderDbContext context)
        {
            base.Seed(context);

            context.Servers.AddRange(TestData.Servers);
            context.Senders.AddRange(TestData.Senders);
            context.Recipients.AddRange(TestData.Recipients);
            context.Recipients.Add(new Recipient { Name = "Recipient from database", Address = "rfd@db.com" });
            context.Mails.AddRange(TestData.Mails);

            context.SaveChanges();
        }
    }
}
