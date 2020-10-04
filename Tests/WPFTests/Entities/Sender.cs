using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Lib.Entities
{
    public class Sender : ICloneable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

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
