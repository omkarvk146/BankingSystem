using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; private set; }    

        public BankAccount(string Owner)
        {
            this.Owner = Owner;
            AccountNumber = Guid.NewGuid();
            Balance = 0;
        }


        public string Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return "Deposit amount must be positive";
            }
            if(amount > 10000)
            {
                return "Deposite Limit Reached";
            }

            Balance += amount;
            return "Deposit Successful";

        }


        public string Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return "Withdrawal amount must be positive";
            }
            if (amount > Balance)
            {
                return "Insufficient amount";
            }
            if(amount > 5000)
            {
                return "Withdrawal Limit Reached";
            }
            Balance -= amount;
            return "Withdrawal Successful";
        }
    }
}
