using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.MVVM
{
    public interface IStore<out T>
    {
        IEnumerable<T> Items { get; }
    }
}
