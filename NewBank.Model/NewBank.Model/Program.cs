using System;
using System.Collections.Generic;

public class Account
{
    public string OwnerFullName { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; }
    public decimal Balance { get; set; }
    public string Password { get; set; }
    public List<Transaction> Transactions { get; set; }

    public Account()
    {
        Transactions = new List<Transaction>();
    }
}

public class Transaction
{
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
}

public class Bank
{
    private List<Account> accounts;

    public Bank()
    {
        accounts = new List<Account>();
    }

    public List<Account> GetAccounts()
    {
        return accounts;
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
    }
}

public class Program
{
    public static void Main()
    {
        Bank bank = new Bank();

        int choice;
        do
        {
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
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        } while (choice != 3);
    }

    public static void CreateAccount(Bank bank)
    {
        Console.WriteLine("CREATE ACCOUNT\n");

        Console.Write("Enter your full name: ");
        string fullName = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

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
            Balance = balance,
            Password = password
        };

        bank.AddAccount(account);

        Console.WriteLine("Account created successfully!");

        // Display the created account details
        PrintAccountDetails(account);
    }

    public static void Login(Bank bank)
    {
        Console.WriteLine("LOGIN\n");

        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        // Find the account by account number and password
        Account account = bank.GetAccounts().Find(a => a.AccountNumber == accountNumber && a.Password == password);

        if (account != null)
        {
            Console.WriteLine($"Welcome, {account.OwnerFullName}!");

            int choice;
            do
            {
                Console.WriteLine("\nMAIN MENU");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Print Statement");
                Console.WriteLine("5. Display Balance");
                Console.WriteLine("6. Set Up Another Account");
                Console.WriteLine("7. Exit");

                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Deposit(account);
                        break;
                    case 2:
                        Withdraw(account);
                        break;
                    case 3:
                        Transfer(account, bank);
                        break;
                    case 4:
                        PrintStatement(account);
                        break;
                    case 5:
                        DisplayBalance(account);
                        break;
                    case 6:
                        CreateAccount(bank);
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 7);
        }
        else
        {
            Console.WriteLine("Invalid account number or password. Please try again.");
        }
    }

    public static void Deposit(Account account)
    {
        Console.WriteLine("DEPOSIT\n");

        Console.Write("Enter the deposit amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        account.Balance += amount;

        // Add the deposit transaction to the account's transaction history
        account.Transactions.Add(new Transaction
        {
            Date = DateTime.Now,
            Description = "Deposit",
            Amount = amount,
            Balance = account.Balance
        });

        Console.WriteLine("Deposit successful!");
    }

    public static void Withdraw(Account account)
    {
        Console.WriteLine("WITHDRAW\n");

        Console.Write("Enter the withdrawal amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (amount > account.Balance)
        {
            Console.WriteLine("Insufficient balance.");
        }
        else
        {
            account.Balance -= amount;

            // Add the withdrawal transaction to the account's transaction history
            account.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = "Withdrawal",
                Amount = amount,
                Balance = account.Balance
            });

            Console.WriteLine("Withdrawal successful!");
        }
    }

    public static void Transfer(Account senderAccount, Bank bank)
    {
        Console.WriteLine("TRANSFER\n");

        Console.Write("Enter the recipient's account number: ");
        string recipientAccountNumber = Console.ReadLine();

        Account recipientAccount = bank.GetAccounts().Find(a => a.AccountNumber == recipientAccountNumber);

        if (recipientAccount == null)
        {
            Console.WriteLine("Recipient account not found.");
        }
        else
        {
            Console.Write("Enter the transfer amount: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());

            if (amount > senderAccount.Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                senderAccount.Balance -= amount;
                recipientAccount.Balance += amount;

                // Add the transfer transaction to the sender's transaction history
                senderAccount.Transactions.Add(new Transaction
                {
                    Date = DateTime.Now,
                    Description = $"Transfer to Account {recipientAccountNumber}",
                    Amount = amount,
                    Balance = senderAccount.Balance
                });

                // Add the transfer transaction to the recipient's transaction history
                recipientAccount.Transactions.Add(new Transaction
                {
                    Date = DateTime.Now,
                    Description = $"Transfer from Account {senderAccount.AccountNumber}",
                    Amount = amount,
                    Balance = recipientAccount.Balance
                });

                Console.WriteLine("Transfer successful!");
            }
        }
    }

    public static void PrintStatement(Account account)
    {
        Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NO {account.AccountNumber}\n");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
        Console.WriteLine("| DATE              | DESCRIPTION                   | AMOUNT                   | BALANCE             |");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");

        foreach (Transaction transaction in account.Transactions)
        {
            Console.WriteLine($"| {transaction.Date} | {transaction.Description} | {transaction.Amount} | {transaction.Balance} |");
        }

        Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
    }

    public static void DisplayBalance(Account account)
    {
        Console.WriteLine($"ACCOUNT DETAILS\n");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
        Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
        Console.WriteLine($"| {account.OwnerFullName,-18} | {account.AccountNumber,-30} | {account.AccountType,-24} | {account.Balance,-19} |");
        Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
    }

    public static void PrintAccountDetails(Account account)
    {
        Console.WriteLine($"ACCOUNT DETAILS\n");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
        Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
        Console.WriteLine($"| {account.OwnerFullName,-18} | {account.AccountNumber,-30} | {account.AccountType,-24} | {account.Balance,-19} |");
        Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
    }

    //public static void SetupAccount(Customer customer, Bank bank)
    //{
    //    Console.WriteLine("\nSET UP ANOTHER ACCOUNT");

    //    Console.Write("Enter a new account number: ");
    //    string accountNumber = Console.ReadLine();

    //    // Check if the account number is already taken
    //    if (bank.GetAccountByNumber(accountNumber) != null)
    //    {
    //        Console.WriteLine("Account number already exists. Please choose a different account number.");
    //        return;
    //    }

    //    Console.Write("Enter a password: ");
    //    string password = Console.ReadLine();

    //    Console.Write("Enter your full name: ");
    //    string fullName = Console.ReadLine();

    //    Console.Write("Enter the initial deposit amount: ");
    //    decimal initialDeposit = Convert.ToDecimal(Console.ReadLine());

    //    // Create a new account for the customer
    //    Account newAccount = new Account(accountNumber, password, fullName, initialDeposit);
    //    customer.AddAccount(newAccount);
    //    bank.AddAccount(newAccount);

    //    Console.WriteLine("Account created successfully!");
    //}
}






//using System;
//using System.Collections.Generic;

//public class Account
//{
//    public string OwnerFullName { get; set; }
//    public string AccountNumber { get; set; }
//    public string AccountType { get; set; }
//    public decimal Balance { get; set; }
//    public string Password { get; set; }
//}

//public class Bank
//{
//    private List<Account> accounts;

//    public Bank()
//    {
//        accounts = new List<Account>();
//    }

//    public List<Account> GetAccounts()
//    {
//        return accounts;
//    }

//    public void AddAccount(Account account)
//    {
//        accounts.Add(account);
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        Bank bank = new Bank();

//        int choice;
//        do
//        {
//            Console.WriteLine("1. Create Account");
//            Console.WriteLine("2. Login");
//            Console.WriteLine("3. Exit");

//            Console.Write("Enter your choice: ");
//            choice = Convert.ToInt32(Console.ReadLine());

//            switch (choice)
//            {
//                case 1:
//                    CreateAccount(bank);
//                    break;
//                case 2:
//                    Login(bank);
//                    break;
//                case 3:
//                    Console.WriteLine("Exiting...");
//                    break;
//                default:
//                    Console.WriteLine("Invalid choice. Please try again.");
//                    break;
//            }

//            Console.WriteLine();
//        } while (choice != 3);
//    }

//    public static void CreateAccount(Bank bank)
//    {
//        Console.WriteLine("CREATE ACCOUNT\n");

//        Console.Write("Enter your full name: ");
//        string fullName = Console.ReadLine();

//        Console.Write("Enter your password: ");
//        string password = Console.ReadLine();

//        // Generate a random account number
//        Random random = new Random();
//        string accountNumber = random.Next(1000000000, 2000000000).ToString();

//        Console.Write("Enter your account type: ");
//        string accountType = Console.ReadLine();

//        Console.Write("Enter your initial balance: ");
//        decimal balance = Convert.ToDecimal(Console.ReadLine());

//        Account account = new Account
//        {
//            OwnerFullName = fullName,
//            AccountNumber = accountNumber,
//            AccountType = accountType,
//            Balance = balance,
//            Password = password
//        };

//        bank.AddAccount(account);

//        Console.WriteLine("Account created successfully!");

//        // Display the created account details
//        Console.WriteLine("Your Account Details:");
//        Console.WriteLine($"Full Name: {account.OwnerFullName}");
//        Console.WriteLine($"Account Number: {account.AccountNumber}");
//        Console.WriteLine($"Account Type: {account.AccountType}");
//        Console.WriteLine($"Balance: {account.Balance}");
//    }

//    public static void Login(Bank bank)
//    {
//        Console.WriteLine("LOGIN\n");

//        Console.Write("Enter your account number: ");
//        string accountNumber = Console.ReadLine();

//        Console.Write("Enter your password: ");
//        string password = Console.ReadLine();

//        // Find the account by account number and password
//        Account account = bank.GetAccounts().Find(a => a.AccountNumber == accountNumber && a.Password == password);

//        if (account != null)
//        {
//            Console.WriteLine($"Welcome, {account.OwnerFullName}!");

//            int choice;
//            do
//            {
//                Console.WriteLine("1. Deposit");
//                Console.WriteLine("2. Withdraw");
//                Console.WriteLine("3. Transfer");
//                Console.WriteLine("4. Print Statement");
//                Console.WriteLine("5. Display Balance");
//                Console.WriteLine("6. Exit");

//                Console.Write("Enter your choice: ");
//                choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Deposit(account);
//                        break;
//                    case 2:
//                        Withdraw(account);
//                        break;
//                    case 3:
//                        Transfer(account, bank);
//                        break;
//                    case 4:
//                        PrintStatement(account);
//                        break;
//                    case 5:
//                        DisplayBalance(account);
//                        break;
//                    case 6:
//                        Console.WriteLine("Exiting...");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }

//                Console.WriteLine();
//            } while (choice != 6);
//        }
//        else
//        {
//            Console.WriteLine("Invalid account number or password. Please try again.");
//        }
//    }

//    public static void Deposit(Account account)
//    {
//        Console.WriteLine("DEPOSIT\n");

//        Console.Write("Enter the deposit amount: ");
//        decimal amount = Convert.ToDecimal(Console.ReadLine());

//        account.Balance += amount;

//        Console.WriteLine("Deposit successful!");
//    }

//    public static void Withdraw(Account account)
//    {
//        Console.WriteLine("WITHDRAW\n");

//        Console.Write("Enter the withdrawal amount: ");
//        decimal amount = Convert.ToDecimal(Console.ReadLine());

//        if (amount > account.Balance)
//        {
//            Console.WriteLine("Insufficient balance.");
//        }
//        else
//        {
//            account.Balance -= amount;
//            Console.WriteLine("Withdrawal successful!");
//        }
//    }

//    public static void Transfer(Account senderAccount, Bank bank)
//    {
//        Console.WriteLine("TRANSFER\n");

//        Console.Write("Enter the recipient's account number: ");
//        string recipientAccountNumber = Console.ReadLine();

//        Account recipientAccount = bank.GetAccounts().Find(a => a.AccountNumber == recipientAccountNumber);

//        if (recipientAccount == null)
//        {
//            Console.WriteLine("Recipient account not found.");
//        }
//        else
//        {
//            Console.Write("Enter the transfer amount: ");
//            decimal amount = Convert.ToDecimal(Console.ReadLine());

//            if (amount > senderAccount.Balance)
//            {
//                Console.WriteLine("Insufficient balance.");
//            }
//            else
//            {
//                senderAccount.Balance -= amount;
//                recipientAccount.Balance += amount;
//                Console.WriteLine("Transfer successful!");
//            }
//        }
//    }

//    public static void PrintStatement(Account account)
//    {
//        Console.WriteLine($"Account Statement for {account.OwnerFullName}");
//        Console.WriteLine("Statement printing logic goes here...");
//    }

//    public static void DisplayBalance(Account account)
//    {
//        Console.WriteLine($"Your current balance is: {account.Balance}");
//    }
//}







//using System;
//using System.Collections.Generic;

//public class Account
//{
//    public string OwnerFullName { get; set; }
//    public string AccountNumber { get; set; }
//    public string AccountType { get; set; }
//    public decimal Balance { get; set; }
//    public string Password { get; set; }
//}

//public class Bank
//{
//    private List<Account> accounts;

//    public Bank()
//    {
//        accounts = new List<Account>();
//    }

//    public List<Account> GetAccounts()
//    {
//        return accounts;
//    }

//    public void AddAccount(Account account)
//    {
//        accounts.Add(account);
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        Bank bank = new Bank();

//        int choice;
//        do
//        {
//            Console.WriteLine("1. Create Account");
//            Console.WriteLine("2. Login");
//            Console.WriteLine("3. Exit");

//            Console.Write("Enter your choice: ");
//            choice = Convert.ToInt32(Console.ReadLine());

//            switch (choice)
//            {
//                case 1:
//                    CreateAccount(bank);
//                    break;
//                case 2:
//                    Login(bank);
//                    break;
//                case 3:
//                    Console.WriteLine("Exiting...");
//                    break;
//                default:
//                    Console.WriteLine("Invalid choice. Please try again.");
//                    break;
//            }

//            Console.WriteLine();
//        } while (choice != 3);
//    }

//    public static void CreateAccount(Bank bank)
//    {
//        Console.WriteLine("CREATE ACCOUNT\n");

//        Console.Write("Enter your full name: ");
//        string fullName = Console.ReadLine();

//        Console.Write("Enter your password: ");
//        string password = Console.ReadLine();

//        // Generate a random account number
//        Random random = new Random();
//        string accountNumber = random.Next(1000000000, 2000000000).ToString();

//        Console.Write("Enter your account type: ");
//        string accountType = Console.ReadLine();

//        Console.Write("Enter your initial balance: ");
//        decimal balance = Convert.ToDecimal(Console.ReadLine());

//        Account account = new Account
//        {
//            OwnerFullName = fullName,
//            AccountNumber = accountNumber,
//            AccountType = accountType,
//            Balance = balance,
//            Password = password
//        };

//        bank.AddAccount(account);

//        Console.WriteLine("Account created successfully!");

//        // Display the created account details
//        Console.WriteLine("Your Account Details:");
//        Console.WriteLine($"Full Name: {account.OwnerFullName}");
//        Console.WriteLine($"Account Number: {account.AccountNumber}");
//        Console.WriteLine($"Account Type: {account.AccountType}");
//        Console.WriteLine($"Balance: {account.Balance}");
//    }

//    public static void Login(Bank bank)
//    {
//        Console.WriteLine("LOGIN\n");

//        Console.Write("Enter your account number: ");
//        string accountNumber = Console.ReadLine();

//        Console.Write("Enter your password: ");
//        string password = Console.ReadLine();

//        // Find the account by account number and password
//        Account account = bank.GetAccounts().Find(a => a.AccountNumber == accountNumber && a.Password == password);

//        if (account != null)
//        {
//            Console.WriteLine($"Welcome, {account.OwnerFullName}!");

//            int choice;
//            do
//            {
//                Console.WriteLine("1. Deposit");
//                Console.WriteLine("2. Withdraw");
//                Console.WriteLine("3. Transfer");
//                Console.WriteLine("4. Print Statement");
//                Console.WriteLine("5. Display Balance");
//                Console.WriteLine("6. Exit");

//                Console.Write("Enter your choice: ");
//                choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        Deposit(account);
//                        break;
//                    case 2:
//                        Withdraw(account);
//                        break;
//                    case 3:
//                        Transfer(account, bank);
//                        break;
//                    case 4:
//                        PrintStatement(account);
//                        break;
//                    case 5:
//                        DisplayBalance(account);
//                        break;
//                    case 6:
//                        Console.WriteLine("Exiting...");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }

//                Console.WriteLine();
//            } while (choice != 6);
//        }
//        else
//        {
//            Console.WriteLine("Invalid account number or password. Please try again.");
//        }
//    }

//    public static void Deposit(Account account)
//    {
//        Console.WriteLine("DEPOSIT\n");

//        Console.Write("Enter the deposit amount: ");
//        decimal amount = Convert.ToDecimal(Console.ReadLine());

//        account.Balance += amount;

//        Console.WriteLine("Deposit successful!");
//    }

//    public static void Withdraw(Account account)
//    {
//        Console.WriteLine("WITHDRAW\n");

//        Console.Write("Enter the withdrawal amount: ");
//        decimal amount = Convert.ToDecimal(Console.ReadLine());

//        if (amount > account.Balance)
//        {
//            Console.WriteLine("Insufficient balance.");
//        }
//        else
//        {
//            account.Balance -= amount;
//            Console.WriteLine("Withdrawal successful!");
//        }
//    }

//    public static void Transfer(Account senderAccount, Bank bank)
//    {
//        Console.WriteLine("TRANSFER\n");

//        Console.Write("Enter the recipient's account number: ");
//        string recipientAccountNumber = Console.ReadLine();

//        Account recipientAccount = bank.GetAccounts().Find(a => a.AccountNumber == recipientAccountNumber);

//        if (recipientAccount == null)
//        {
//            Console.WriteLine("Recipient account not found.");
//        }
//        else
//        {
//            Console.Write("Enter the transfer amount: ");
//            decimal amount = Convert.ToDecimal(Console.ReadLine());

//            if (amount > senderAccount.Balance)
//            {
//                Console.WriteLine("Insufficient balance.");
//            }
//            else
//            {
//                senderAccount.Balance -= amount;
//                recipientAccount.Balance += amount;
//                Console.WriteLine("Transfer successful!");
//            }
//        }
//    }

//    public static void PrintStatement(Account account)
//    {
//        // Statement printing logic...
//    }

//    public static void DisplayBalance(Account account)
//    {
//        Console.WriteLine($"Your current balance is: {account.Balance}");
//    }
//}








//using System;
//using System.Collections.Generic;

//public class Account
//{
//    public string OwnerFullName { get; set; }
//    public string AccountNumber { get; set; }
//    public string AccountType { get; set; }
//    public decimal Balance { get; set; }
//    public string Password { get; set; }
//}

//public class Bank
//{
//    private List<Account> accounts;

//    public Bank()
//    {
//        accounts = new List<Account>();
//    }

//    public List<Account> GetAccounts()
//    {
//        return accounts;
//    }

//    public void AddAccount(Account account)
//    {
//        accounts.Add(account);
//    }
//}

//public class Program
//{
//    public static void Main()
//    {
//        Bank bank = new Bank();

//        int choice;
//        do
//        {
//            Console.WriteLine("1. Create Account");
//            Console.WriteLine("2. Login");
//            Console.WriteLine("3. Exit");

//            Console.Write("Enter your choice: ");
//            choice = Convert.ToInt32(Console.ReadLine());

//            switch (choice)
//            {
//                case 1:
//                    CreateAccount(bank);
//                    break;
//                case 2:
//                    Login(bank);
//                    break;
//                case 3:
//                    Console.WriteLine("Exiting...");
//                    break;
//                default:
//                    Console.WriteLine("Invalid choice. Please try again.");
//                    break;
//            }

//            Console.WriteLine();
//        } while (choice != 3);
//    }

//    public static void CreateAccount(Bank bank)
//    {
//        Console.WriteLine("CREATE ACCOUNT\n");

//        Console.Write("Enter your full name: ");
//        string fullName = Console.ReadLine();

//        Console.Write("Enter your password: ");
//        string password = Console.ReadLine();

//        // Generate a random account number
//        Random random = new Random();
//        string accountNumber = random.Next(1000000000, 2000000000).ToString();

//        Console.Write("Enter your account type: ");
//        string accountType = Console.ReadLine();

//        Console.Write("Enter your initial balance: ");
//        decimal balance = Convert.ToDecimal(Console.ReadLine());

//        Account account = new Account
//        {
//            OwnerFullName = fullName,
//            AccountNumber = accountNumber,
//            AccountType = accountType,
//            Balance = balance,
//            Password = password
//        };

//        bank.AddAccount(account);

//        Console.WriteLine("Account created successfully!");

//        // Display the created account details
//        Console.WriteLine("Your Account Details:");
//        Console.WriteLine($"Full Name: {account.OwnerFullName}");
//        Console.WriteLine($"Account Number: {account.AccountNumber}");
//        Console.WriteLine($"Account Type: {account.AccountType}");
//        Console.WriteLine($"Balance: {account.Balance}");
//    }

//    //public static void Login(Bank bank)
//    //{
//    //    Console.WriteLine("LOGIN\n");

//    //    Console.Write("Enter your account number: ");
//    //    string accountNumber = Console.ReadLine();

//    //    // Find the account by account number
//    //    Account account = bank.GetAccounts().Find(a => a.AccountNumber == accountNumber);

//    //    if (account != null)
//    //    {
//    //        Console.WriteLine($"Welcome, {account.OwnerFullName}!");

//    //        int choice;
//    //        do
//    //        {
//    //            Console.WriteLine("1. Create Another Account");
//    //            Console.WriteLine("2. Deposit");
//    //            Console.WriteLine("3. Withdraw");
//    //            Console.WriteLine("4. Transfer");
//    //            Console.WriteLine("5. Print Statement");
//    //            Console.WriteLine("6. Display Balance");
//    //            Console.WriteLine("7. Exit");

//    //            Console.Write("Enter your choice: ");
//    //            choice = Convert.ToInt32(Console.ReadLine());

//    //            switch (choice)
//    //            {
//    //                case 1:
//    //                    CreateAccount(bank);
//    //                    break;
//    //                case 2:
//    //                    Deposit(account);
//    //                    break;
//    //                case 3:
//    //                    Withdraw(account);
//    //                    break;
//    //                case 4:
//    //                    Transfer(account, bank);
//    //                    break;
//    //                case 5:
//    //                    PrintStatement(account);
//    //                    break;
//    //                case 6:
//    //                    DisplayBalance(account);
//    //                    break;
//    //                case 7:
//    //                    Console.WriteLine("Exiting...");
//    //                    break;
//    //                default:
//    //                    Console.WriteLine("Invalid choice. Please try again.");
//    //                    break;
//    //            }

//    //            Console.WriteLine();
//    //        } while (choice != 7);
//    //    }
//    //    else
//    //    {
//    //        Console.WriteLine("Account not found. Please try again.");
//    //    }
//    //}
//    public static void Login(Bank bank)
//    {
//        Console.WriteLine("LOGIN\n");

//        Console.Write("Enter your account number: ");
//        string accountNumber = Console.ReadLine();

//        Console.Write("Enter your password: ");
//        string password = Console.ReadLine();

//        // Find the account by account number and password
//        Account account = bank.GetAccounts().Find(a => a.AccountNumber == accountNumber && a.Password == password);

//        if (account != null)
//        {
//            Console.WriteLine($"Welcome, {account.OwnerFullName}!");

//            int choice;
//            do
//            {
//                Console.WriteLine("1. Create Another Account");
//                Console.WriteLine("2. Deposit");
//                Console.WriteLine("3. Withdraw");
//                Console.WriteLine("4. Transfer");
//                Console.WriteLine("5. Print Statement");
//                Console.WriteLine("6. Display Balance");
//                Console.WriteLine("7. Exit");

//                Console.Write("Enter your choice: ");
//                choice = Convert.ToInt32(Console.ReadLine());

//                switch (choice)
//                {
//                    case 1:
//                        CreateAccount(bank);
//                        break;
//                    case 2:
//                        Deposit(bank);
//                        break;
//                    case 3:
//                        Withdraw(bank);
//                        break;
//                    case 4:
//                        Transfer(bank);
//                        break;
//                    case 5:
//                        PrintStatement(account);
//                        break;
//                    case 6:
//                        DisplayBalance(account);
//                        break;
//                    case 7:
//                        Console.WriteLine("Exiting...");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        break;
//                }

//                Console.WriteLine();
//            } while (choice != 7);
//        }
//        else
//        {
//            Console.WriteLine("Invalid account number or password. Please try again.");
//        }
//    }


//    //public static void Deposit(Account account)
//    //{
//    //    Console.WriteLine("DEPOSIT\n");

//    //    Console.Write("Enter the deposit amount: ");
//    //    decimal amount = Convert.ToDecimal(Console.ReadLine());

//    //    account.Balance += amount;

//    //    Console.WriteLine("Deposit successful!");
//    //}
//    public static void Deposit(Bank bank)
//    {
//        Console.WriteLine("DEPOSIT\n");

//        Console.Write("Enter your account number: ");
//        string accountNumber = Console.ReadLine();

//        // Find the account by account number
//        Account account = bank.GetAccounts().Find(a => a.AccountNumber == accountNumber);

//        if (account != null)
//        {
//            Console.Write("Enter the deposit amount: ");
//            decimal amount = Convert.ToDecimal(Console.ReadLine());

//            account.Balance += amount;

//            Console.WriteLine("Deposit successful!");
//        }
//        else
//        {
//            Console.WriteLine("Account not found. Please try again.");
//        }
//    }


//    //public static void Withdraw(Account account)
//    //{
//    //    Console.WriteLine("WITHDRAW\n");

//    //    Console.Write("Enter the withdrawal amount: ");
//    //    decimal amount = Convert.ToDecimal(Console.ReadLine());

//    //    if (amount > account.Balance)
//    //    {
//    //        Console.WriteLine("Insufficient balance.");
//    //    }
//    //    else
//    //    {
//    //        account.Balance -= amount;
//    //        Console.WriteLine("Withdrawal successful!");
//    //    }
//    //}
//    public static void Withdraw(Bank bank)
//    {
//        Console.WriteLine("WITHDRAW\n");

//        Console.Write("Enter your account number: ");
//        string accountNumber = Console.ReadLine();

//        // Find the account by account number
//        Account account = bank.GetAccounts().Find(a => a.AccountNumber == accountNumber);

//        if (account != null)
//        {
//            Console.Write("Enter the withdrawal amount: ");
//            decimal amount = Convert.ToDecimal(Console.ReadLine());

//            if (amount > account.Balance)
//            {
//                Console.WriteLine("Insufficient balance.");
//            }
//            else
//            {
//                account.Balance -= amount;
//                Console.WriteLine("Withdrawal successful!");
//            }
//        }
//        else
//        {
//            Console.WriteLine("Account not found. Please try again.");
//        }
//    }


//    //public static void Transfer(Account senderAccount, Bank bank)
//    //{
//    //    Console.WriteLine("TRANSFER\n");

//    //    Console.Write("Enter the recipient's account number: ");
//    //    string recipientAccountNumber = Console.ReadLine();

//    //    Account recipientAccount = bank.GetAccounts().Find(a => a.AccountNumber == recipientAccountNumber);

//    //    if (recipientAccount == null)
//    //    {
//    //        Console.WriteLine("Recipient account not found.");
//    //    }
//    //    else
//    //    {
//    //        Console.Write("Enter the transfer amount: ");
//    //        decimal amount = Convert.ToDecimal(Console.ReadLine());

//    //        if (amount > senderAccount.Balance)
//    //        {
//    //            Console.WriteLine("Insufficient balance.");
//    //        }
//    //        else
//    //        {
//    //            senderAccount.Balance -= amount;
//    //            recipientAccount.Balance += amount;
//    //            Console.WriteLine("Transfer successful!");
//    //        }
//    //    }
//    //}
//    public static void Transfer(Bank bank)
//    {
//        Console.WriteLine("TRANSFER\n");

//        Console.Write("Enter your account number: ");
//        string senderAccountNumber = Console.ReadLine();

//        // Find the sender account by account number
//        Account senderAccount = bank.GetAccounts().Find(a => a.AccountNumber == senderAccountNumber);

//        if (senderAccount != null)
//        {
//            Console.Write("Enter the recipient's account number: ");
//            string recipientAccountNumber = Console.ReadLine();

//            // Find the recipient account by account number
//            Account recipientAccount = bank.GetAccounts().Find(a => a.AccountNumber == recipientAccountNumber);

//            if (recipientAccount != null)
//            {
//                Console.Write("Enter the transfer amount: ");
//                decimal amount = Convert.ToDecimal(Console.ReadLine());

//                if (amount > senderAccount.Balance)
//                {
//                    Console.WriteLine("Insufficient balance.");
//                }
//                else
//                {
//                    senderAccount.Balance -= amount;
//                    recipientAccount.Balance += amount;
//                    Console.WriteLine("Transfer successful!");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Recipient account not found.");
//            }
//        }
//        else
//        {
//            Console.WriteLine("Sender account not found.");
//        }
//    }


//    public static void PrintStatement(Account account)
//    {
//        // Statement printing logic...
//    }

//    public static void DisplayBalance(Account account)
//    {
//        Console.WriteLine($"Your current balance is: {account.Balance}");
//    }
//}
