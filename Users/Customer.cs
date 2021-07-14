using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Users
{
    class Customer
    {
        private User _user { get; }

        public Customer(User user)
        {
            _user = user;
        }

        public bool Withdrawal(int amount)
        {
            return true;
        }
        public void DisplayBalance()
        {

        }
        public bool Deposit(int amount)
        {
            return true;
        }
    }
}
