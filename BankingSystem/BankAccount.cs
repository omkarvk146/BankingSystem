using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public Guid AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        private const decimal MaxDeposit = 10000;
        private const decimal MaxWithdraw = 5000;

        public BankAccount(string owner)
        {
            Owner = owner;
            AccountNumber = Guid.NewGuid();
            Balance = 0;
        }

        public BankAccount(Guid accNo, string owner, decimal balance)
        {
            AccountNumber = accNo;
            Owner = owner;
            Balance = balance;
        }

        public string Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return "Deposit amount must be positive";
            }

            if (amount > 10000)
            {
                return "Deposit Limit Reached";
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
                return "Insufficient balance";
            }

            if (amount > 5000)
            {
                return "Withdrawal limit reached";
            }

            Balance -= amount;
            return "Withdrawal Successful";
        }

    }
}
