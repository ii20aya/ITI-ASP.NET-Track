using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;

        public BankAccount(string customerName, double balance)
        {
            if (balance < 0)
                throw new ArgumentOutOfRangeException(nameof(balance));

            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName => m_customerName;

        public double Balance => m_balance;

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            m_balance += amount;
        }

        public void Withdrawal(double amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (amount > m_balance)
                throw new InvalidOperationException("Insufficient balance");

            m_balance -= amount;
        }

        public void Transfer(double amount, BankAccount from, BankAccount to)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount > from.m_balance)
            {
                throw new InvalidOperationException("Insufficient balance");
            }

            from.m_balance -= amount;
            to.m_balance += amount;
        }
    }
}