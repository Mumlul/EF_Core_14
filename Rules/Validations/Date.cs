using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_Core.Rules.Validations
{
    public class Date:ValidationRule
    {
        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            if (value == null)
                return new ValidationResult(false, "Выберите дату");

            if (value is DateTime selectedDate)
            {
                if (selectedDate < DateTime.Today)
                    return new ValidationResult(false, "Дата не может быть раньше сегодняшней");
            }
            else
            {
                return new ValidationResult(false, "Неверный формат даты");
            }

            return ValidationResult.ValidResult;
        }
    }
}
