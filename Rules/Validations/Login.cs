using EF_Core.Models.Context;
using EF_Core.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_Core.Rules.Validations
{
    public class Login:ValidationRule
    {
        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 4) return new ValidationResult(false, "Длина логина минимум 5 символов");

            if (!Unique_login(input))
                return new ValidationResult(false, "Логин должен быть уникальным");

            return ValidationResult.ValidResult;
        }

        private bool Unique_login(string login)
        {
            using (var context = new AppDbContext())
            {
                int loginCount = context.Users
               .Count(u => u.Login.ToLower() == login.ToLower());
                if (loginCount>1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
