using EF_Core.Models.Context;
using EF_Core.Models.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_Core.Rules.Validations
{
    public class Email:ValidationRule
    {
                    
        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            var input =(value??"").ToString().Trim();

            if (!input.Contains('@')) return new ValidationResult(false, "В поле должен быть символ @");

            if (!Unique_email(input)) return new ValidationResult(false, "Email должен быть уникальным");
            
            var emailRegex = new System.Text.RegularExpressions.Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            
            if (!emailRegex.IsMatch(input))
            {
                return new ValidationResult(false, "Неверный формат email");
            }

            return ValidationResult.ValidResult;
        }

        public bool Unique_email(string email)
        {
            using (var context = new AppDbContext())
            {
                int loginCount = context.Users
               .Count(u => u.Email.ToLower() == email.ToLower());

                if (loginCount>1)
                    return false;
            }

            return true;
        }
    }
}
