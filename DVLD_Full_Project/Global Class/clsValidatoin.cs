using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD_Full_Project.Global_Class
{
    public static class clsValidatoin
    {
        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            return Regex.IsMatch(email, pattern);
        }
        private static bool ValidateInteger(string number)
        {
            Regex regex = new Regex(@"^[0-9]+$");
            return regex.IsMatch(number);
        }
        private static bool ValidateFloat(string number)
        {
            Regex regex = new Regex(@"^(\d+\.\d*|\d+)$");
            return regex.IsMatch(number);
        }
        public static bool IsNumber(string number)
        {
            return (ValidateInteger(number)|| ValidateFloat(number));
        }
    }
}
