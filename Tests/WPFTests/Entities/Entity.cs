using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Entities
{
    public class Entity
    {
        public int Id { get; set; }

        public override string ToString() => $"Id = {Id}";
    }
}
