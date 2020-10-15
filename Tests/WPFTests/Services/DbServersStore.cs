using System.Collections.Generic;
using System.Linq;
using MailSender.Lib.Data;
using MailSender.Lib.Entities;
using MailSender.Interfaces;
using MailSender.Services;

namespace MailSender.Services
{
    public class DbServersStore : DbStore<Server, MailSenderDbContext>, IServersStore
    {
        public DbServersStore(IDbContextService<MailSenderDbContext> dbContextService) : base(dbContextService)
        {
        }

        public override IEnumerable<Server> GetItems()
        {
            using (var db = DbContextService.GetDbContext())
                return db.Servers.ToArray();
        }

        public override Server GetById(int id)
        {
            using (var db = DbContextService.GetDbContext())
                return db.Servers.FirstOrDefault(r => r.Id == id);
        }

        public override int Create(Server item)
        {
            using (var db = DbContextService.GetDbContext())
            {
                var dbItem = db.Servers.Add(item);
                db.SaveChanges();
                return dbItem.Id;
            }
        }

        public override void Update(int id, Server item)
        {
            using (var db = DbContextService.GetDbContext())
            {
                var dbServer = db.Servers.FirstOrDefault(r => r.Id == item.Id);
                if (dbServer == null)
                    return;

                dbServer.Name = item.Name;
                dbServer.Address = item.Address;
                dbServer.Port = item.Port;
                dbServer.UseSSL = item.UseSSL;
                dbServer.Login = item.Login;
                dbServer.Password = item.Password;

                db.SaveChanges();
            }
        }

        //public override Server Delete(int id)
        //{
        //    var dbServer = GetById(id);
        //    if (dbServer == null)
        //        return null;

        //    using (var db = DbContextService.GetDbContext())
        //    {
        //        db.Entry(dbServer).State = EntityState.Deleted;
        //        db.SaveChanges();
        //    }

        //    return dbServer;
        //}
    }
}
