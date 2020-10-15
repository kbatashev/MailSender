using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public abstract class DbStore<TEntity, TDbContext> : IStore<TEntity> where TDbContext : DbContext, new()
    {
        protected readonly IDbContextService<TDbContext> DbContextService;

        protected DbStore(IDbContextService<TDbContext> dbContextService) => DbContextService = dbContextService;

        public abstract IEnumerable<TEntity> GetItems();

        public abstract TEntity GetById(int id);

        public abstract int Create(TEntity item);

        public abstract void Update(int id, TEntity item);

        public TEntity Delete(int id)
        {
            var dbItem = GetById(id);
            if (dbItem == null)
                return default;

            using (var db = DbContextService.GetDbContext())
            {
                db.Entry(dbItem).State = EntityState.Deleted;
                db.SaveChanges();
            }

            return dbItem;
        }
    }
}
