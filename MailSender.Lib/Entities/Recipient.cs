using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Lib.Entities
{
    public class Recipient
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public override string ToString() => Name;
    }
}
