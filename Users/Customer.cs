using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ATM.Registration;
using static System.Int16;

namespace ATM.Users
{
    class Customer : User
    {
        private User _user { get; }
        private int _balance;
        private static readonly int _accountNumber = (int) (new Random().NextDouble() * 1000000000);

        public User User
        {
            get => _user;
        }
        public Customer(User user)
        {
            _user = user;
            _balance = 20000; // default
        }

        public void Withdrawal()
        {
            if (EnterPin())
            {
                Console.Write("Enter amount of money to withdraw: ");
                String amount = Console.ReadLine();
                if (!Validation.IsDigits(amount)) return;
                int withdrawAmount = Parse(amount ?? string.Empty);
                if (withdrawAmount <= _balance)
                {
                    if (withdrawAmount > 0)
                    {
                        _balance -= withdrawAmount;
                        Console.WriteLine("You successively withdraw money!");
                        DisplayReceipt(_balance, GetCurrentMethod());
                    }
                    else
                    {
                        Console.WriteLine("Enter positive amount!");
                    }
                }
                else
                {
                    Console.WriteLine("Not enough balance on your account!");
                }
            }
            else
            {
                Console.WriteLine("Entered wrong PIN!");
            }
        }
        public void DisplayBalance()
        {
            if(EnterPin())
                Console.WriteLine("Balance: $" + _balance + ".");
            else
            {
                Console.WriteLine("Entered wrong PIN!");
            }
        }
        public void Deposit()
        {
            if (EnterPin())
            {
                Console.Write("Enter amount of money to deposit: ");
                var amount = Console.ReadLine();
                if (!Validation.IsDigits(amount)) return;
                int depositAmount = Parse(amount ?? string.Empty);

                if (depositAmount > 0)
                    _balance += depositAmount;
                else
                {
                    Console.WriteLine("Enter positive amount!");
                }
                DisplayReceipt(_balance, GetCurrentMethod());
            }
            else
            {
                Console.WriteLine("Entered wrong PIN!");
            }
        }

        public  bool EnterPin()
        {
            Console.Write("Enter PIN: ");
            var pin = Console.ReadLine();
            if (Validation.IsPinValid(pin))
            {
                var Pin = Int16.Parse(pin);
                if (Pin == _user.Pin)
                    return true;
            }

            return false;
        }

        public static void DisplayReceipt(int balanceAfter, string nameOfOperation)
        {
            Console.WriteLine("\nRECEIPT");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Balance after operation " + nameOfOperation.ToUpper() + ": $" + balanceAfter + ".");
            Console.WriteLine("Time of operation: " + DateTime.Now);
            Console.WriteLine("Number of account: " + _accountNumber);
            Console.WriteLine("----------------------------------------------------\n");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private string GetCurrentMethod()
        {
            var str = new StackTrace();
            var sf = str.GetFrame(1);

            return sf.GetMethod().Name;
        }
    }
}
