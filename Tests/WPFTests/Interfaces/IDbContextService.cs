using System;
using System.Data.Entity;

namespace MailSender.Interfaces
{
    public interface IDbContextService<TDbContext> where TDbContext : DbContext, new()
    {
      
        TDbContext GetDbContext();
    }
}
