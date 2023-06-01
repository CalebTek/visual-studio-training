using Bank.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Collector
{
    public class CustomerRepository
    {
        public static Registration RegisterUser()
        {
            IUserInput userInput = new ConsoleUserInput();
            Registration user = new Registration()
            {
                FirstName = userInput.GetFirstName(),
                LastName = userInput.GetLastName(),
                OtherName = userInput.GetOtherName(),
                EmailAddress = userInput.GetEmailAddress(),
                Password = userInput.GetPassword(),
                AccountType = userInput.GetAccountType()
            };
            Console.WriteLine($"Registration Successful");
            Console.WriteLine($"Account Number is: {user.AccountNo}");
            //customerList.Add( user );

            return user;
        }

    }
}
