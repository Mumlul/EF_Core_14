using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_Core.Rules.Validations
{
    public class TextRules:ValidationRule
    {
        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            var input = value?.ToString().Trim();

            if (input.Any(c => !char.IsLetter(c))) return new ValidationResult(false, "Не должен содержать цифры");

            return ValidationResult.ValidResult;
        }
    }
}
