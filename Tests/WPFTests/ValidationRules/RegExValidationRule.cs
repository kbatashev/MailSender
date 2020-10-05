using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailSender.ValidationRules
{
    class RegExValidationRule : ValidationRule
    {
        private Regex _regex;

        public string Pattern
        {
            get => _regex?.ToString();
            set => _regex = string.IsNullOrWhiteSpace(value) ? null : new Regex(value);
        }

        public bool AllowNull { get; set; }

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
                return AllowNull
                    ? ValidationResult.ValidResult
                    : new ValidationResult(false, "отсутствует ссылка на строку");

            if (_regex == null)
                return ValidationResult.ValidResult;

            return _regex.IsMatch(value is string s ? s : value.ToString())
                ? ValidationResult.ValidResult
                : new ValidationResult(false, ErrorMessage ?? "неизвестная ошибка");
        }
    }
}
