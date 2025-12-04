using EF_Core.Migrations;
using EF_Core.Models.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_Core.Rules.Validations
{
    public class Group : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            using (var context = new AppDbContext())
            {
                if (context.InterestGroups.Any(u => u.Title.ToLower() == input.ToLower()))
                {
                    return new ValidationResult(false, "Такое уже используется");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}
