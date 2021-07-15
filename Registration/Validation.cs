using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using ATM.Data;
using static System.Char;

namespace ATM.Registration
{
    public class Validation
    {
        public static bool IsNameLastNameValid(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$"); 
        }

        public static bool IsDigits(string str)
        {
            return str.All(IsDigit);
        }

        public static bool IsPinValid(string pin)
        {
            return (pin.Length == 4) && (pin.All(IsDigit));
        }

        public static bool IsMailValid(string mail)
        {
            return new MailAddress(mail).Host.Contains(".");
        }

        public static bool IsPasswordLoginValid(string str)
        {
            return (str.Length is >= 4 and <= 20) && (!(str.Contains(" ")));
        }

        public static void ErrorInfo()
        {
            Console.WriteLine("Invalid parameter entered! Register again!");
        }

        public static bool IsValidTypeAndRange(char c, int numOfOperations)
        {
            if (IsDigit(c))
            {
                return c - '0' >= 1 && c - '0' <= numOfOperations;
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
                if (!user.Login.Equals(login)) continue;
                string encodedPassword = DataUser.DecodePassowrd(user.Password);
                if (encodedPassword.Equals(password))
                    return true;
            }
            return false;
        }
    }
}
