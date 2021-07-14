using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Users;

namespace ATM.Registration
{
    class Registration
    {
        public static void Register()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("You chose to register!\n");
            String name = Console.ReadLine();
            String lastName = Console.ReadLine();
            int pin = Console.Read();
            String login = Console.ReadLine();
            String mail = Console.ReadLine();

            // zarejestruj go w bazie
            Customer customer = new Customer(new User
            {
                LastName = lastName,
                Login = login,
                Mail = mail,
                Name = name,
                Pin = pin
            });
        }
    }
}
