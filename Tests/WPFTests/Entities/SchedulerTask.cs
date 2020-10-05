using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Lib.Entities;

namespace MailSender.Entities
{
    public class SchedulerTask : Entity
    {
        public DateTime Time { get; set; }

        public Server Server { get; set; }

        public Sender Sender { get; set; }

        public MailingList MailingList { get; set; }
    }
}
