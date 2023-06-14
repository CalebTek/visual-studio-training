using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchBank
{
    public class Account : Customer
    {
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Account()
        {
            Transactions = new List<Transaction>();
        }

    }


}
