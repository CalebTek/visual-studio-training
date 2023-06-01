using System;
using System.Collections.Generic;

public class Bank
{
    private List<Account> accounts;

    public Bank()
    {
        accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }

    public List<Account> GetAccounts()
    {
        return accounts;
    }

    public void DisplayAccountDetails()
    {
        Console.WriteLine("ACCOUNT DETAILS\n");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
        Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");

        foreach (var account in accounts)
        {
            Console.WriteLine($"| {account.OwnerFullName,-17} | {account.AccountNumber,-30} | {account.AccountType,-24} | {account.Balance,-19} |");
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
        }
    }
}

public class Account
{
    public string OwnerFullName { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    private List<Transaction> transactions;

    public Account()
    {
        transactions = new List<Transaction>();
    }

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public void DisplayAccountStatement()
    {
        Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NO {AccountNumber}\n");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
        Console.WriteLine("| DATE              | DESCRIPTION                   | AMOUNT                   | BALANCE             |");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");

        decimal runningBalance = Balance;

        foreach (var transaction in transactions)
        {
            runningBalance += transaction.Amount;
            Console.WriteLine($"| {transaction.Date,-17} | {transaction.Description,-30} | {transaction.Amount,-24} | {runningBalance,-19} |");
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
        }
    }
}

public class Transaction
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new Bank();

        int choice;
        do
        {
            Console.WriteLine("Welcome to the Bank");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateAccount(bank);
                    break;
                case 2:
                    Login(bank);
                    break;
                case 3:
                    Console.WriteLine("Thank you for using the Bank. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
        while (choice != 3);

        Console.ReadLine();
    }

    //public static void CreateAccount(Bank bank)
    //{
    //    Console.WriteLine("CREATE ACCOUNT\n");

    //    Console.Write("Enter your full name: ");
    //    string fullName = Console.ReadLine();

    //    Console.Write("Enter your account number: ");
    //    string accountNumber = Console.ReadLine();

    //    Console.Write("Enter your account type: ");
    //    string accountType = Console.ReadLine();

    //    Console.Write("Enter your initial balance: ");
    //    decimal balance = Convert.ToDecimal(Console.ReadLine());

    //    Account account = new Account
    //    {
    //        OwnerFullName = fullName,
    //        AccountNumber = accountNumber,
    //        AccountType = accountType,
    //        Balance = balance
    //    };

    //    bank.AddAccount(account);

    //    Console.WriteLine("Account created successfully!");
    //}
    //public static void CreateAccount(Bank bank)
    //{
    //    Console.WriteLine("CREATE ACCOUNT\n");

    //    Console.Write("Enter your full name: ");
    //    string fullName = Console.ReadLine();

    //    // Generate a random account number
    //    Random random = new Random();
    //    string accountNumber = random.Next(1000000000, 2000000000).ToString();

    //    Console.Write("Enter your account type: ");
    //    string accountType = Console.ReadLine();

    //    Console.Write("Enter your initial balance: ");
    //    decimal balance = Convert.ToDecimal(Console.ReadLine());

    //    Account account = new Account
    //    {
    //        OwnerFullName = fullName,
    //        AccountNumber = accountNumber,
    //        AccountType = accountType,
    //        Balance = balance
    //    };

    //    bank.AddAccount(account);

    //    Console.WriteLine("Account created successfully!");
    //}

    public static void CreateAccount(Bank bank)
    {
        Console.WriteLine("CREATE ACCOUNT\n");

        Console.Write("Enter your full name: ");
        string fullName = Console.ReadLine();

        // Generate a random account number
        Random random = new Random();
        string accountNumber = random.Next(1000000000, 2000000000).ToString();

        Console.Write("Enter your account type: ");
        string accountType = Console.ReadLine();

        Console.Write("Enter your initial balance: ");
        decimal balance = Convert.ToDecimal(Console.ReadLine());

        Account account = new Account
        {
            OwnerFullName = fullName,
            AccountNumber = accountNumber,
            AccountType = accountType,
            Balance = balance
        };

        bank.AddAccount(account);

        Console.WriteLine("Account created successfully!");

        // Display the created account details
        Console.WriteLine("Your Account Details:");
        Console.WriteLine($"Full Name: {account.OwnerFullName}");
        Console.WriteLine($"Account Number: {account.AccountNumber}");
        Console.WriteLine($"Account Type: {account.AccountType}");
        Console.WriteLine($"Balance: {account.Balance}");
    }



    public static void Login(Bank bank)
    {
        Console.WriteLine("LOGIN\n");

        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        // Find the account by account number
        Account account = bank.GetAccounts().Find(a => a.AccountNumber == accountNumber);

        if (account != null)
        {
            Console.WriteLine($"Welcome, {account.OwnerFullName}!");

            // Perform account operations or display account details
            // For simplicity, let's just display the account details here
            Console.WriteLine("Your Account Details:");
            Console.WriteLine($"Full Name: {account.OwnerFullName}");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Account Type: {account.AccountType}");
            Console.WriteLine($"Balance: {account.Balance}");
        }
        else
        {
            Console.WriteLine("Account not found. Please try again.");
        }
    }
}
