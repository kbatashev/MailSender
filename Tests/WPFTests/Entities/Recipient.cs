using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Entities;

namespace MailSender.Lib.Entities
{
    public class Recipient: PersonEntity
    {
        public override string ToString() => Name;
    }
}
