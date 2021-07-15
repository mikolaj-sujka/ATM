using System;
using ATM.Data;
using ATM.Users;

namespace ATM.Registration
{
    class Registration
    {
        public static void Register()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("You chose to register!\n");
            EntryInfo();
            Console.WriteLine("----------------------------------------------------");
            var correctEntered = false;

            while (!correctEntered)
            {
                Console.Write("Enter your name: ");
                var name = Console.ReadLine();

                if (Validation.IsNameLastNameValid(name))
                {
                    Console.Write("Enter your last name: ");
                    var lastName = Console.ReadLine();

                    if (Validation.IsNameLastNameValid(lastName))
                    {
                        Console.Write("Enter your mail: ");
                        var mail = Console.ReadLine();

                        if (Validation.IsMailValid(mail))
                        {
                            Console.Write("Enter your login: ");
                            var login = Console.ReadLine();
                            if (Validation.IsPasswordLoginValid(login))
                            {
                                Console.Write("Enter your password: ");
                                var password = Console.ReadLine();

                                if (Validation.IsPasswordLoginValid(password))
                                {
                                    Console.Write("Enter your password again: ");
                                    var repeatPassword = Console.ReadLine();
                                    if (password != null && Validation.IsPasswordLoginValid(repeatPassword) && password.Equals(repeatPassword))
                                    {
                                        Console.Write("Enter your PIN: ");
                                        var pin = Console.ReadLine();

                                        if (Validation.IsPinValid(pin))
                                        {
                                            correctEntered = true;
                                            var customer = new Customer(new User
                                            {
                                                LastName = lastName,
                                                Login = login,
                                                Mail = mail,
                                                Name = name,
                                                Pin = Int16.Parse(pin),
                                                Password = DataUser.EncodePassowrd(password)
                                            });
                                            Console.WriteLine(DataUser.SaveUserData(customer.User)
                                                ? "New account registered!"
                                                : "Login/mail is already used!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Passwords do not match!");
                                    }

                                }
                               
                            }
                            
                        }
                        
                    }
                   
                }
                Validation.ErrorInfo();
            }
        }
        private static void EntryInfo()
        {
            Console.WriteLine("\n\t\t\t\t\tEntry info provided to user who wants to register.\n" +
                              "\n\t\t1. Name and Last Name can contains only letters." +
                              "\n\t\t2. Login can contains digits, letters etc. Login must have length from 4 to " +
                              "20 letters, no spaces etc." +
                              "\n\t\t3. Pin can contains only digits. Pin must have length equal 4 digits." +
                              "\n\t\t4. Password must contains digits, letters etc. Password must have length" +
                              "from 4 to 20, no spaces etc." +
                              "\n\t\t5. Mail must contains '@'.");
        }
    }
}
