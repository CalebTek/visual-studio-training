using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Common
{
    public class Withdraw
    {
        public Withdraw() { }

        //Fields
        public long Amount { get; set; }
        public long SourceAccount { get; set; }
        public decimal Balance { get; set; }

        // Methods
        public bool Validate(Registration customer) 
        {
            bool isValid = true;
            //if (SourceAccount != customer.AccountNo) 
            //{
            //    isValid = false;
            //}
            return isValid; 
        }

        public decimal Withdarawal(long amount, Registration customer)
        {
            if (Validate(customer))
            {
                //Balance balance = new Balance();
                Balance -= amount;
                
            }
            return Balance;
        }

    }
}
