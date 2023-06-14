using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchBank
{
    internal class Withdrawal
    {
        public void Withdraw(Account account)
        {
            Console.WriteLine("Enter the amount");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            //Console.WriteLine($"Balance before: {account.Balance}");
            account.Balance -= amount;
            Console.WriteLine("Withdrawal successful");
            //Console.WriteLine($"Balance after: {account.Balance}");

            account.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Withdrawal",
                Amount = amount,
                Balance = account.Balance
            });
        }
    }
}
