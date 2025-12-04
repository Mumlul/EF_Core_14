using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_Core.Rules.Validations
{
    public class Phone_number : ValidationRule
    {
        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Введите номер телефона");

            string phone = value.ToString();

            string digitsOnly = Regex.Replace(phone, @"[^\d]", "");

            if (Regex.IsMatch(phone, @"[a-zA-Z]"))
                return new ValidationResult(false, "Номер не должен содержать буквы");

            if (digitsOnly.Length != 11)
                return new ValidationResult(false, "Номер должен содержать 11 цифр");

            if (!digitsOnly.StartsWith("7"))
                return new ValidationResult(false, "Номер должен начинаться с 7");

            return ValidationResult.ValidResult;
        }
    }
}
