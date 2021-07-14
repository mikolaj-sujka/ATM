using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ATM.Registration
{
    public class Validation
    {
        public static bool IsNameLastNameValid(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$"); // contains only letters
        }

        public static bool IsPinValid(String pin)
        {
            return (pin.Length == 4) && (pin.All(char.IsDigit));
        }

        public static bool IsMailValid(String mail)
        {
            return new MailAddress(mail).Host.Contains(".");
        }

        public static bool IsPasswordLoginValid(String str)
        {
            return (str.Length is >= 4 and <= 20) && (!(str.Contains(" ")));
        }

        public static void ErrorInfo()
        {
            Console.WriteLine("Invalid parameter entered! Enter again!");
        }
    }
}
