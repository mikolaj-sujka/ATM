using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATM.Registration
{
    public class Validation
    {
        public static bool IsNameLastNameValid(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$"); // contains only letters
        }

        public static bool IsPinValid(int pin)
        {
            return (pin is >= 0000 and <= 9999 && (pin.ToString().Length == 4));
        }

        public static bool IsMailValid(String mail)
        {
            return new MailAddress(mail).Host.Contains(".");
        }

        public static bool IsPasswordLoginValid(String str)
        {
            return (str.Length is >= 4 and <= 20) && (String.IsNullOrWhiteSpace(str));
        }

        public static void ErrorInfo()
        {
            Console.WriteLine("Invalid parameter entered! Enter again!");
        }
    }
}
