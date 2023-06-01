using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Bank.Model.Common
{
    public class Registration
    {
        enum AccountTypes
        {
            Savings = 1, Current = 2
        }
        public Registration() 
        {

        }

        // Fields
        //public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }

        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public int AccountType { get; set; }
        
        //public string DOB { get; set; }
        public string FullName =>
            OtherName == ""? 
            $"{LastName} {FirstName}".Trim() : $"{LastName} {FirstName} {OtherName}".Trim();
        private Random AccountTemp = new Random();
        public string AccountNo => AccountType == 1 ?
                    // code here
                    "0" + Convert.ToString(AccountTemp.Next()).Substring(0, 9) : AccountType == 2 ?
                    //Code here
                    "1" + Convert.ToString(AccountTemp.Next()).Substring(0, 9) : null; 
    }
}
