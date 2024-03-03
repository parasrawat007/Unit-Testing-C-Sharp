using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        private readonly ILogBook _logBook;
        public int Balance { get; set; }

        public BankAccount(ILogBook logBook)
        {
            Balance = 0;
            _logBook=logBook;
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit Invoked");
            Balance += amount;
            return true;
        }

        public bool Withdraw(int amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
            
        }

        public int GetBalance() 
        { 
            return Balance;
        }
    }
}
