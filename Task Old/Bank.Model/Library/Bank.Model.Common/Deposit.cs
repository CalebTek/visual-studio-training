using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Common
{
    public class Deposit
    {
        public Deposit() { }

        //Fields
       public long Amount { get; set; }
        public long Balance { get; set; }

        public long TargetAccount { get; set; }

        //Methods

        public bool Validate() 
        {
            bool isvalid = true;
            if (TargetAccount != 1) // Use dictionary <Key => AccountNo, Tvalue => AccountName>
            {
                // Code here
                isvalid = false;
            }
            return isvalid;
        }


        public long DepositAmount(long amount) 
        {
            if (Validate())
            {
                Balance += amount;
            }
            return Balance; 
        }
    }
}
