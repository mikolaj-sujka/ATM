﻿
namespace ATM.Users
{
    class Customer : User
    {
        private User _user { get; }

        // dodaj ilosc pieniedzy na koncie ... + funkcjonalnosc + readme

        public User User
        {
            get => _user;
        }
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
