using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_Core.Rules.Validations
{
    public class Empty : ValidationRule
    {
        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if(input.Length == 0)  return new ValidationResult(false,"Поле не может быть пустым");

            return ValidationResult.ValidResult;

        }
    }
}
