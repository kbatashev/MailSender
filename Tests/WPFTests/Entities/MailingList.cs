using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Lib.Entities;

namespace MailSender.Entities
{
    public class MailingList: Entity
    {
        public ICollection<Recipient> Recipients { get; set; } = new List<Recipient>();
    }
}
