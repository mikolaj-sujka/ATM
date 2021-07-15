using System;
using ATM.Data;
using ATM.Registration;
using static ATM.Login.Login;
using static ATM.Registration.Registration;

namespace ATM.View
{
    class AtmView
    {
        public static void ActionChoice()
        {
            bool exitChoice = false;
            DataUser.UpdateUsersOldData();

            while (!exitChoice)
            {
                EntryInfo();
                Console.Write("Your choice: ");

                try
                {
                    char choice = Convert.ToChar(Console.ReadLine()!);

                    if (Validation.IsValidTypeAndRange(choice, 3))
                    {
                        switch (choice)
                        {
                            case '1': Register(); DataUser.CreateJsonFile(); break;
                            case '2': LogIn(); break;
                            case '3': Exit(); exitChoice = true; DataUser.CreateJsonFile(); break;
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

        private static void Exit()
        {
            Console.WriteLine("You chose exit! Thank you for your time!");
        }

        private static void EntryInfo()
        {
            Console.WriteLine("\n\t\t\t\t\tWelcome in ATM simulator!\n\t " +
                              "\t\tChoose action:\t 1. REGISTER\n" +
                              "\t\t\t\t\t 2. LOGIN\n" +
                              "\t\t\t\t\t 3. EXIT");
        }
    }
}
