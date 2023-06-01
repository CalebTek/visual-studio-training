using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Model.Collector;
using Bank.Model.Common;

namespace Bank.Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDisplay display = new ConsoleDisplay();
            IUserInput userInput = new ConsoleUserInput();
            Registration registration = new Registration();
            var customerList = new List<Registration>();

            display.DisplayMenu();
            var choice = userInput.GetChoice();
            while (choice !=3 )
            {            
                bool input = true;
                while (input)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Registration customer = CustomerRepository.RegisterUser();
                            customerList.Add(customer);
                            userInput.GotoNext();
                            Console.Clear();
                            input = false;
                            display.DisplayMenu();
                            break;
                        case 2:
                            Console.Clear();
                            //choice = userInput.GetChoice();
                            Login login = new Login();
                            bool isLogin = login.LoginCustomer(customerList);
                            if (isLogin)
                            {
                                display.DisplayUserMenu();
                            }
                            Console.WriteLine("Incorrect details");

                            //choice = userInput.GetChoice();
                            input = false;
                            display.DisplayMenu();
                            break;

                    }
                }
                choice = userInput.GetChoice();

                
            }
            foreach (var item in customerList)
            {
                Console.WriteLine(item);
            }




            //display.DisplayUserMenu();
            //userInput.GetChoice();

        }
    }
}
