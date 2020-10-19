using System;
using System.Data.Entity;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public class DbContextService<TDbContext> : IDbContextService<TDbContext> where TDbContext : DbContext, new()
    {
        //public object Do(Func<TDbContext, object> action)
        //{
        //    using (var db = new TDbContext()) 
        //        return action?.Invoke(db);
        //}

        public TDbContext GetDbContext() => new TDbContext();
    }
}
