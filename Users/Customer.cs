using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Users
{
    class Customer
    {
        private User _user { get; set; }

        public Customer(User user)
        {
            _user = user;
        }

        // override funkcje (jesli bedzie trzeba) + dodaj funkcjonalnosc dodatkowa
    }
}
