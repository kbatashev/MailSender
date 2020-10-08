using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Interfaces
{
    public interface IDataManager<T>
    {
        IEnumerable<T> Read();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
