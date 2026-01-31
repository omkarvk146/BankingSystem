using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystem
{
    public class SavingsAccount : BankAccount
    {
        public Decimal InterestRate { get; set; }

        public SavingsAccount(string Owner, Decimal InterestRate) : base(Owner)
        {
            this.InterestRate = InterestRate;
        }
    }
}
