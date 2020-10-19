using System.Data.Entity;
using System.Diagnostics;
using MailSender.Lib.Entities;


namespace MailSender.Data
{
    public class MailSenderDbContext : DbContext
    {
        public DbSet<Server> Servers { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<MailingList> MailingLists { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }


        public MailSenderDbContext() : base("MailSenderDbConnection")
        {
            Database.SetInitializer(new MailSenderDbInitializer());

            Database.Log = s => Debug.WriteLine(s);
        }
    }
}
