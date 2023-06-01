using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.Collector
{
    public class ConsoleUserInput : IUserInput
    {
        public string GetAccountNo()
        {
            //throw new NotImplementedException();
            Console.Write("Enter your Account No: ");
            return Console.ReadLine();
        }

        public int GetAccountType()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Choose Account type:");
            Console.WriteLine("1. saving:");
            Console.WriteLine("2. Current");
            return int.Parse(Console.ReadLine());
        }

        public double GetAmount()
        {
            //throw new NotImplementedException();
            Console.Write("Enter the Amount: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public int GetChoice()
        {
            //throw new NotImplementedException();
            Console.Write("Enter your choice: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public string GetEmailAddress()
        {
            //throw new NotImplementedException();
            Console.Write("Enter your email address: ");
            return Console.ReadLine();
        }

        public string GetFirstName()
        {
            //throw new NotImplementedException();
            Console.Write("Enter your First Name: ");
            return Console.ReadLine();
        }

        public string GetLastName()
        {
            //throw new NotImplementedException();
            Console.Write("Enter your Last Name: ");
            return Console.ReadLine();

        }

        public string GetOtherName()
        {
            //throw new NotImplementedException();
            Console.Write("Enter your Other Name: ");
            return Console.ReadLine();

        }

        public string GetPassword()
        {
            //throw new NotImplementedException();
            Console.Write("Enter your Password: ");
            return Console.ReadLine();

        }

        public string GetPhoneNumber()
        {
            //throw new NotImplementedException();
            Console.Write("Enter your Phone Number: ");
            return Console.ReadLine();

        }

        public string GetSourceAccount()
        {
            //throw new NotImplementedException();
            Console.Write("Enter the account you want to transfer or withdraw from: ");
            return Console.ReadLine();

        }

        public string GetTargetAccount()
        {
            //throw new NotImplementedException();
            Console.Write("Enter the account you want to transfer to: ");
            return Console.ReadLine();
        }

        public string GotoNext()
        {
            //throw new NotImplementedException();
            Console.Write("Press Enter to Continue:");
            return Console.ReadLine();
        }
    }
}
