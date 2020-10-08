using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MailSender.Entities;
using MailSender.Interfaces;

namespace MailSender.Services
{
    public abstract class DebugStore<T> : IStore<T> where T : Entity
    {
        private readonly List<T> _items;


        public IEnumerable<T> GetItems() => _items;

        public T GetById(int id) => _items?.FirstOrDefault(item => item.Id == id);

        public int Create(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (_items.Contains(item))
                return item.Id;

            item.Id = _items.Count == 0 ? 1 : _items.Max(i => i.Id) + 1;
            _items.Add(item);
            return item.Id;
        }

        public abstract void Update(int id, T item);

        public T Delete(int id)
        {
            var dbItem = GetById(id);
            _items.Remove(dbItem);
            return dbItem;
        }

        public void SaveChanges() => Debug.WriteLine($"{GetType().Name}.SaveChanges()");

        protected DebugStore(IEnumerable<T> items = null) =>
            _items = items != null ? new List<T>(items) : new List<T>();
    }
}
