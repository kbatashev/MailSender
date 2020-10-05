using System;
using System.Collections.Generic;
using System.Text;
using MailSender.Entities;

namespace MailSender.Lib.Entities
{
    public class Server: Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public ushort Port { get; set; }
        public bool UseSSL { get; set; } = true;
        public string Login { get; set; }
        public string Password { get; set; }
        public override string ToString() => Name;
    }
}
