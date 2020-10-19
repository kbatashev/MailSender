using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using MailSender.Lib.Data;
using MailSender.Lib.Entities;
using MailSender.Interfaces;
using MailSender.Services;

namespace MailSender.Services
{
    public class DbRecipientsStore : DbStore<Recipient, MailSenderDbContext>, IRecipientsStore
    {
        public DbRecipientsStore(IDbContextService<MailSenderDbContext> dbContextService) : base(dbContextService)
        {
        }

        public override IEnumerable<Recipient> GetItems()
        {
            //return DbContextService.Do(db =>
            //{
            //    var recipients = db.Recipients.ToArray();
            //    return recipients;
            //}) as IEnumerable<Recipient>;
            using (var db = DbContextService.GetDbContext())
                return db.Recipients.ToArray();
        }

        public override Recipient GetById(int id)
        {
            using (var db = DbContextService.GetDbContext())
                return db.Recipients.FirstOrDefault(r => r.Id == id);
        }

        public override int Create(Recipient item)
        {
            using (var db = DbContextService.GetDbContext())
            {
                var dbItem = db.Recipients.Add(item);
                db.SaveChanges();
                return dbItem.Id;
            }
        }

        public override void Update(int id, Recipient item)
        {
            using (var db = DbContextService.GetDbContext())
            {
                var dbRecipient = db.Recipients.FirstOrDefault(r => r.Id == item.Id);
                if (dbRecipient == null)
                    return;

                dbRecipient.Name = item.Name;
                dbRecipient.Address = item.Address;

                db.SaveChanges();
            }
        }

        //public override Recipient Delete(int id)
        //{
        //    var dbRecipient = GetById(id);
        //    if (dbRecipient == null)
        //        return null;

        //    using (var db = DbContextService.GetDbContext())
        //    {
        //        db.Entry(dbRecipient).State = EntityState.Deleted;
        //        db.SaveChanges();
        //    }

        //    return dbRecipient;
        //}
    }
}
