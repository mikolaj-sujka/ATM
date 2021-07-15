using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Data;
using ATM.Registration;
using ATM.View;

namespace ATM.Login
{
    internal class Login
    {
        public static void LogIn()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("You chose to sign in!\n");
            int chancesToLogIn = 3;

            while (chancesToLogIn >= 0)
            {
                Console.Write("Enter your login: ");
                var login = Console.ReadLine();
                if (Validation.IsLoginExist(login))
                {
                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();
                    if (Validation.IsPasswordValid(password, login))
                    {
                        CustomerView.CustomerActionChoice(login);
                        Console.WriteLine("You have logged in successfully!");
                    }
                    else
                    {
                        Console.WriteLine("This password is incorrect! Try again! You have " + chancesToLogIn + " left.");
                        chancesToLogIn--;
                    }
                }
                else
                {
                    Console.WriteLine("This login is incorrect! Try again! You have " + chancesToLogIn + " left.");
                    chancesToLogIn--;
                }
            }
        }
    }
}
