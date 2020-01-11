using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Res2019
{
    public class DateFormatCheck : IDateFormatCheck
    {
        public bool Check_YYYY_MM_DD_Format(string input)
        {
            bool output = false;
            string pattern = @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$";
            if (!((String.IsNullOrWhiteSpace(input)) || (String.IsNullOrEmpty(input))))
            {
                Regex regex = new Regex(pattern);
                output = regex.IsMatch(input);
            }
            return output;
        }
    }
}
