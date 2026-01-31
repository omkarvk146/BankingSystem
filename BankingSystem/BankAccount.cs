using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    public class BankAccount
    {
        public string Owner { get; set; }
        public Guid AccountNumber { get; }
        public decimal Balance { get; private set; }

        private const decimal MaxDeposit = 10000;
        private const decimal MaxWithdraw = 5000;

        public BankAccount(string owner)
        {
            Owner = owner;
            AccountNumber = Guid.NewGuid();
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Deposit amount must be positive");

            if (amount > MaxDeposit)
                throw new Exception("Deposit limit reached");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Withdrawal amount must be positive");

            if (amount > MaxWithdraw)
                throw new Exception("Withdrawal limit reached");

            if (amount > Balance)
                throw new Exception("Insufficient balance");

            Balance -= amount;
        }
    }
}
