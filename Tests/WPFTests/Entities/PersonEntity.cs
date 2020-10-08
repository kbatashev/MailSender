using System.Text.RegularExpressions;

namespace MailSender.Entities
{
    public class PersonEntity : NamedEntity
    {
        public string Address { get; set; }

        public override string ToString() => base.ToString() + $", Address = {Address}";

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Address):
                        if (!new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(Address))
                            return "неверный формат email-адреса";
                        break;
                }

                return base[columnName];
            }
        }
    }
}
