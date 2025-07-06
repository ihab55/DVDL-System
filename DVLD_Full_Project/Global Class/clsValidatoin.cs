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
    }
}
