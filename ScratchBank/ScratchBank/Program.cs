using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                        _bank.CreateAccount(_bank);
                        break;
                    case "2":
                        _bank.Log(_bank);
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


        }



    }

}
