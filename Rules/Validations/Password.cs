using EF_Core.Models.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Controls;

namespace EF_Core.Rules.Validations
{
    public class Password:ValidationRule
    {
        private char[] spec_simbols = new[] {'_','!','#','$','%',')','(','&'};

        public UserService UserService { get; set; } = new();

        public override ValidationResult Validate(object? value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();

            if (input.Length < 8) return new ValidationResult(false, "Длина пароля должна быть больше 7 символов");

            if (!input.Any(c => spec_simbols.Contains(c))) return new ValidationResult(false, "Пароль должен содержать спец символ");

            if (!input.Any(char.IsUpper)) return new ValidationResult(false, "В пароле должна быть с верхним регистром");

            if (!input.Any(char.IsLower)) return new ValidationResult(false, "В пароле должна быть буква с нижним регистром");

            return ValidationResult.ValidResult;
        }

        public bool Unique_password(string password)
        {
            int count = 0;

            foreach (var user in UserService.Users)
            {
                if (user.Password == password) count++;
                if(count>=2) return false;
            }

            return true;
        }
    }
}
