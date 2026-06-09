using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class BankAccount
    {

        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public void Withdraw(decimal amount)
        {
        
            if (amount > Balance)
            {
                
                throw new InsufficientBalanceException("not enough!");
            }

            Balance -= amount;
            Console.WriteLine($" current : {Balance}");
        }
    }
}
