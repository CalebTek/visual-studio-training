using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ScratchBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = "accountDB.txt";
            Bank _bank = new Bank(fileLocation);
            string choice;

            Thread startThread = new Thread(() => 
            {
                do
                {
                    Console.WriteLine("1. Create Account\n2. Login\n3. Exit");

                    do
                    {
                        Console.WriteLine("Enter your choice");
                        choice = Console.ReadLine();

                    } while (!Validate.Choice(choice));


                    switch (choice)
                    {
                        case "1":
                            Thread createAccountThread = new Thread(() => 
                            {
                                _bank.CreateAccount(_bank);
                            });
                            createAccountThread.Start();
                            createAccountThread.Join();
                            break;
                        case "2":
                            Thread loginThread = new Thread(() => 
                            {
                                _bank.Log(_bank);
                            });
                            loginThread.Start();
                            loginThread.Join();
                            break;
                        case "3":
                            Console.WriteLine("Exit..");
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                    //choice = Console.ReadLine();
                } while (choice != "3");

            });

            startThread.Start();
            Thread.Sleep(1000);
            startThread.Join();
             


        }



    }

}
