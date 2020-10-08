using System.ComponentModel;

namespace MailSender.Entities
{
    public class NamedEntity : Entity, IDataErrorInfo
    {
        public string Name { get; set; }

        public override string ToString() => base.ToString() + $", Name = {Name}";

        public virtual string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Name):

                        if (string.IsNullOrWhiteSpace(Name))
                            return "Имя не может быть пустым";
                        if (Name.Length < 2)
                            return "Имя не может быть короче двух символов";
                        if (Name.Length > 30)
                            return "Имя не может быть длинее 30 символов";
                        break;
                }

                return null;
            }
        }

        public virtual string Error => null;
    }
}
