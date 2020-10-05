using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Entities;

namespace MailSender.Lib.Entities
{
    public class Sender : PersonEntity, ICloneable
    {
        public string Comment { get; set; }

        public override string ToString() => Name;

        public object Clone() => new Sender
        {
            Name = Name?.Clone() as string,
            Address = Address?.Clone() as string,
            Comment = Comment?.Clone() as string
        };
    }
}
