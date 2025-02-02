using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class BankAccount
    {
        decimal amount;

        public BankAccount(decimal initAmount)
        {
            this.Amount = initAmount;
        }

        public decimal Amount
        {
            get
            {
                return this.amount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount can not be negative!");
                }
                else
                {
                    this.amount = value;
                }
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit can not be negative!");
            }
            this.Amount += amount;
        }
        // sample comment
        public void Withdraw(decimal amount)
        {
            decimal totalWithdrawal;

            if (amount < 1000)
            {
                totalWithdrawal = amount + (amount * 0.05m);
            }
            else
            {
                totalWithdrawal = amount + (amount * 0.02m);
            }

            // Ensure there are sufficient funds before deducting
            if (this.Amount < totalWithdrawal)
            {
                throw new InvalidOperationException("Insufficient funds!");
            }

            this.Amount -= totalWithdrawal;
        }

    }
}
