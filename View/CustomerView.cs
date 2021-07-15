using System;
using ATM.Data;
using ATM.Registration;
using ATM.Users;
using Nelibur.ObjectMapper;

namespace ATM.View
{
    class CustomerView
    {
        public static void CustomerActionChoice(string login)
        {
            bool logOut = false;
            EntryInfo(login);
            var customer = DataUser.FindCustomer(login);

            while (!logOut)
            {
                Console.Write("Your choice: ");

                try
                {
                    char choice = Convert.ToChar(Console.ReadLine()!);

                    if (Validation.IsValidTypeAndRange(choice, 4))
                    {
                        switch (choice)
                        {
                            case '1': customer.DisplayBalance(); break;
                            case '2': customer.Withdrawal(); break;
                            case '3': customer.Deposit(); break;
                            case '4': logOut = true; break;
                        }
                    }
                    else
                        Console.WriteLine("Wrong parameter entered! Try again!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entered parameter should has length equal 1!");
                }
            }

        }

        private static void EntryInfo(string login)
        {
            Console.WriteLine("\n\t\t\t\t\tWelcome in your account " + login + "!\n\t " +
                              "\t\tChoose action:\t 1. DISPLAY BALANCE.\n" +
                              "\t\t\t\t\t 2. WITHDRAWAL.\n" +
                              "\t\t\t\t\t 3. DEPOSIT.\n" +
                              "\t\t\t\t\t 4. LOG OUT.");
        }
    }
}
