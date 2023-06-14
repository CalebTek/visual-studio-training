using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchBank
{
    internal class Transfer
    {
        public void Transfers(Account account, Bank bank)
        {
            Console.WriteLine("Enter the destination account number");
            string destinationAccountNumber = Console.ReadLine();

            Account destinationAccount = bank.GetAccounts().Find(a => a.AccountNumber == destinationAccountNumber);

            if (destinationAccount != null)
            {
                Console.WriteLine("Enter the amount");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                //Console.WriteLine($"My Balance before: {account.Balance}");
                //Console.WriteLine($"Receipient Balance before: {destinationAccount.Balance}");
                account.Balance -= amount;
                destinationAccount.Balance += amount;
                Console.WriteLine("transfer successful");
                //Console.WriteLine($"My Balance after: {account.Balance}");
                //Console.WriteLine($"Receipient Balance after: {destinationAccount.Balance}");

                account.Transactions.Add(new Transaction
                {
                    Date = DateTime.Now,
                    Description = $"Transfer to {destinationAccount.AccountNumber}",
                    Amount = amount,
                    Balance = account.Balance
                });

                destinationAccount.Transactions.Add(new Transaction
                {
                    Date = DateTime.Now,
                    Description = $"Transfer from {account.AccountNumber}",
                    Amount = amount,
                    Balance = destinationAccount.Balance
                });


            }
            else
            {
                Console.WriteLine("Destination Account number not found");
            }
            
        }
    }
}
