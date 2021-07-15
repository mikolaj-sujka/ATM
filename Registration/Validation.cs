using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ATM.Data;

namespace ATM.Registration
{
    public class Validation
    {
        public static bool IsNameLastNameValid(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$"); 
        }

        public static bool IsDigits(String str)
        {
            return str.All(char.IsDigit);
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

        public static bool IsValidTypeAndRange(char c, int numOfOperations)
        {
            if (Char.IsDigit(c))
            {
                if (c - '0' >= 1 && c - '0' <= numOfOperations)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool IsLoginExist(string login)
        {
            var users = DataUser.ReadUserData();
            foreach (var user in users)
            {
                if (user.Login.Equals(login))
                    return true;
            }

            return false;
        }

        public static bool IsPasswordValid(string password, string login)
        {
            var users = DataUser.ReadUserData();
            foreach (var user in users)
            {
                if (user.Login.Equals(login))
                {
                    if (user.Password.Equals(password))
                        return true;
                }
            }
            return false;
        }
    }
}
