using System.ComponentModel.DataAnnotations;
using MailSender.Lib.Entities;

namespace MailSender.Entities
{
    public class Mail : Entity
    {
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
