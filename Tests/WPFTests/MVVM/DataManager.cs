using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.MVVM
{
    public abstract class DataManager<T>
    {
        public abstract IEnumerable<T> Read();
        public abstract void Add(T item);
        public abstract void Update(T item);
        public abstract void Delete(T item);
    }
}
