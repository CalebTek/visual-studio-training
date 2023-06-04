using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace OneBank
{
    internal class Dashboard
    {
        public string? FullName { get; private set; }

        public void Menu()
        {
            Console.WriteLine("*Welcome to the menu page*");
            Console.WriteLine("Please select from the following options:");
            Console.WriteLine("1. Setup Account");
            Console.WriteLine("2. Check Balance");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Withdraw");
            Console.WriteLine("5. Statement Of Account");
            Console.WriteLine("6. Account Info");
            Console.WriteLine("7. Transfer");
            Console.WriteLine("8. Logout");

            Console.WriteLine();

            string option = Console.ReadLine();
            Console.WriteLine(option);

            bool isValidOption = int.TryParse(option, out int selectedOption);
            if (!isValidOption || selectedOption < 1 || selectedOption > 8)
            {
                Console.WriteLine("Invalid input. Please enter a valid menu option (1-8).");
                Menu();
            }
            else
            {
                HandleMenuOption(selectedOption);
            }
        }

        private void HandleMenuOption(int option)
        {
            switch (option)
            {
                case 1:
                    SetupAccount();
                    Menu();
                    break;
                case 2:
                    CheckBalance();
                    Menu();
                    break;
                case 3:
                    Deposit();
                    Menu();
                    break;
                case 4:
                    Withdraw();
                    Menu();
                    break;
                case 5:
                    //Console.WriteLine("Below is your account info");
                    Print print = new Print();
                    print.Out();
                    Console.WriteLine("Thank you for banking with us!!!");
                    Menu();
                    break;
                case 6:
                    Console.WriteLine("Below is your statement of account");
                    break;
                case 7:
                    Console.WriteLine("Enter the amount you want to transfer");
                    break;
                case 8:
                    //Print print = new Print();
                    //print.Out();
                    Console.WriteLine("Thank you for banking with us!!!");
                    break;
            }
        }

        private void SetupAccount() // pass in the register list to know who want to create account
        {
            string accountType = "";
            Console.WriteLine("Select Account type:");
            Console.WriteLine("1. Current Account");
            Console.WriteLine("2. Savings Account");

            string accountTypeInput = Console.ReadLine();
            bool isValidAccountType = int.TryParse(accountTypeInput, out int selectedAccountType);
            if (!isValidAccountType || (selectedAccountType != 1 && selectedAccountType != 2))
            {
                Console.WriteLine("Invalid input. Please enter a valid account type (1 or 2).");
                SetupAccount();
                return;
            }

            if (selectedAccountType == 1)
            {
                accountType = "current";

                Random random = new Random();
                var accountNumber = random.Next(1000000000, 2099999999).ToString();
                Console.WriteLine($"Your Current Account number is: {accountNumber}");

                decimal accountBalance = 0;
                Console.WriteLine($"Your current account balance is: {accountBalance}");

                Console.WriteLine("Make an initial deposit:");
                decimal deposit;
                if (!decimal.TryParse(Console.ReadLine(), out deposit) || deposit < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid deposit amount.");
                    SetupAccount();
                    return;
                }

                accountBalance += deposit;
                Console.WriteLine($"Your initial deposit is: {deposit}");

                Accountinfo all = new Accountinfo(FullName, accountNumber, accountType, accountBalance);
                Program.AllInfo.Add(all);
            }
            else if (selectedAccountType == 2)
            {
                accountType = "savings";

                Random random = new Random();
                var accountNumber = random.Next(1000000000, 2099999999).ToString();
                Console.WriteLine($"Your Savings Account number is: {accountNumber}");

                decimal accountBalance = 0;
                Console.WriteLine($"Your account balance is: {accountBalance}");

                Console.WriteLine("Make an initial deposit:");
                decimal deposit;
                if (!decimal.TryParse(Console.ReadLine(), out deposit) || deposit < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a valid deposit amount.");
                    SetupAccount();
                    return;
                }

                // Update the account balance with the deposit amount
                accountBalance += deposit;
            }
        }

        private void CheckBalance()
        {
            Console.WriteLine("Please enter your Account Number:");
            string accountNumber = Console.ReadLine();

            foreach (Accountinfo account in Program.AllInfo)
            {
                if (account.Accountnumber == accountNumber)
                {
                    Console.WriteLine($"Your balance for account number {accountNumber} is {account.Accountbalance}");
                    return;
                }
            }

            Console.WriteLine("Account number not found. Please try again.");
        }

        private void Deposit()
        {
            Console.WriteLine("Please enter your Account Number:");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter the amount to deposit:");
            decimal deposit;
            if (!decimal.TryParse(Console.ReadLine(), out deposit) || deposit < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid deposit amount.");
                Deposit();
                return;
            }

            foreach (Accountinfo account in Program.AllInfo)
            {
                if (account.Accountnumber == accountNumber)
                {
                    account.Accountbalance += deposit;
                    Console.WriteLine($"Your account balance for {accountNumber} is {account.Accountbalance}");
                    return;
                }
            }

            Console.WriteLine("Account number not found. Please try again.");
        }

        private void Withdraw()
        {
            Console.WriteLine("Please enter your Account Number:");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter the amount you want to Withdraw:");
            decimal withdraw;
            if (!decimal.TryParse(Console.ReadLine(), out withdraw) || withdraw < 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid withdrawal amount.");
                Withdraw();
                return;
            }

            foreach (Accountinfo account in Program.AllInfo)
            {
                if (account.Accountnumber == accountNumber)
                {
                    if (withdraw <= account.Accountbalance)
                    {
                        account.Accountbalance -= withdraw;
                        Console.WriteLine($"Your account balance for {accountNumber} is {account.Accountbalance}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance. Please enter a valid withdrawal amount.");
                    }

                    return;
                }
            }

            Console.WriteLine("Account number not found. Please try again.");
        }
    }
}