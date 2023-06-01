using Bank.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Bank.Model.Collector
{
    public class Login
    {
        public string AccountNo { get; set; }
        public string Password { get; set; }

        //public bool Validate(List<Registration> registrations)
        //{
        //    return registrations.Any(registration =>
        //        registration.AccountNo == AccountNo && registration.Password == Password);
        //}
        public bool Validate(List<Registration> registrations)
        {
            return registrations.Any(registration =>
                registration.AccountNo == AccountNo && registration.Password == Password);
        }


        //public bool LoginCustomer(List<Registration> registrations)
        //{
        //    IUserInput userInput = new ConsoleUserInput();

        //    AccountNo = userInput.GetAccountNo();
        //    Password = userInput.GetPassword();

        //    return Validate(registrations);
        //}
        public bool LoginCustomer(List<Registration> registrations)
        {
            IUserInput userInput = new ConsoleUserInput();

            AccountNo = userInput.GetAccountNo();
            Password = userInput.GetPassword();

            return Validate(registrations);
        }

    }


    //public class Login
    //{
    //    public Login() { }

    //    //Fields
    //    //public string UserName { get; set; }
    //    public string Password { get; set; }
    //    //public string Email { get; set; }
    //    public string AccountNo { get; set; }

    //    // Methods
    //    public bool Validate(List<Registration> customer) 
    //    {
    //        bool isValid = true;
    //        foreach (Registration registration in customer)
    //        {
    //            if (registration.AccountNo != AccountNo)
    //            {
    //                isValid = false;
    //            }
    //            if (registration.Password != Password)
    //            {
    //                isValid = false;
    //            }
    //        }
    //        return isValid;
    //    }

    //    public  bool LoginCustomer(List<Registration> customer)
    //    {
    //        IUserInput userInput = new ConsoleUserInput();
    //        Login login = new Login()
    //        {
    //            AccountNo = userInput.GetAccountNo(),
    //            Password = userInput.GetPassword(),
    //        };
    //        bool isValid = true;
    //        if (!Validate(customer))
    //        {
    //            isValid &= LoginCustomer(customer);
    //        }
    //        return isValid;
    //    }
    //}
}
