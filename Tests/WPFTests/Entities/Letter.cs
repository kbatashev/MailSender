
using MailSender.Entities;

namespace MailSender.Lib.Entities
{
    public class Letter: Entity
    {
    
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
