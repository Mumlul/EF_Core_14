using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EF_Core.Rules.Convertors
{
    public class Phone : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long phoneLong && phoneLong > 0)
            {
                return phoneLong.ToString("0 (000) 000 00-00");
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string phoneStr)
            {
                string digits = Regex.Replace(phoneStr, @"[^\d]", "");
                if (long.TryParse(digits, out long result))
                {
                    return result;
                }
            }
            return 0L;
        }
    }
}
