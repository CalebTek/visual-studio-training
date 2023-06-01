using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Bank.App
{
    //    internal class Program
    //    {
    //        static void Main(string[] args)
    //        {


    //            IAccount account = new Account();
    //            account.FullName = "John Doe";
    //            account.AccountNumber = "1234567890";
    //            account.AccountType = "Checking";
    //            account.Balance = 1000;

    //            IBalancePrinter balancePrinter = new ConsoleBalancePrinter();
    //            balancePrinter.PrintBalance(account);

    //            IUserInput userInput = new ConsoleUserInput();
    //            int choice = userInput.GetChoice();

    //            switch (choice)
    //            {
    //                case 1:
    //                    double amount = userInput.GetAmount();
    //                    account.Deposit(amount);
    //                    break;
    //                case 2:
    //                    amount = userInput.GetAmount();
    //                    account.Withdraw(amount);
    //                    break;
    //                case 3:
    //                    string fromAccountNumber = userInput.GetFromAccount();
    //                    string toAccountNumber = userInput.GetToAccount();

    //                    CheckingAccount fromAccount = new CheckingAccount();
    //                    fromAccount.AccountNumber = fromAccountNumber;

    //                    CheckingAccount toAccount = new CheckingAccount();
    //                    toAccount.AccountNumber = toAccountNumber;

    //                    amount = userInput.GetAmount();
    //                    fromAccount.Transfer(amount, toAccount);
    //                    break;
    //                default:
    //                    Console.WriteLine("Invalid choice.");
    //                    break;
    //            }

    //            balancePrinter.PrintBalance(account);
    //        }



    //        public interface IAccount
    //        {
    //        string FullName { get; set; }
    //        string AccountNumber { get; set; }
    //        string AccountType { get; set; }
    //        double Balance { get; set; }

    //        void Deposit(double amount);
    //        void Withdraw(double amount);
    //    }

    //    public class Account : IAccount
    //    {
    //        public string FullName { get; set; }
    //        public string AccountNumber { get; set; }
    //        public string AccountType { get; set; }
    //        public double Balance { get; set; }

    //        public void Deposit(double amount)
    //        {
    //            Balance += amount;
    //        }

    //        public void Withdraw(double amount)
    //        {
    //            Balance -= amount;
    //        }
    //    }

    //    public class CheckingAccount : IAccount
    //    {
    //        public string FullName { get; set; }
    //        public string AccountNumber { get; set; }
    //        public string AccountType { get; set; }
    //        public double Balance { get; set; }

    //        public void Deposit(double amount)
    //        {
    //            Balance += amount;
    //        }

    //        public void Withdraw(double amount)
    //        {
    //            Balance -= amount;
    //        }

    //        public void Transfer(double amount, CheckingAccount toAccount)
    //        {
    //            Withdraw(amount);
    //            toAccount.Deposit(amount);
    //        }
    //    }

    //    public class SavingsAccount : IAccount
    //    {
    //        public string FullName { get; set; }
    //        public string AccountNumber { get; set; }
    //        public string AccountType { get; set; }
    //        public double Balance { get; set; }
    //        public double InterestRate { get; set; }

    //        public void Deposit(double amount)
    //        {
    //            Balance += amount;
    //        }

    //        public void Withdraw(double amount)
    //        {
    //            Balance -= amount;
    //        }

    //        public void CalculateInterest()
    //        {
    //            double interest = Balance * InterestRate;
    //            Deposit(interest);
    //        }
    //    }

    //    public interface IBalancePrinter
    //    {
    //        void PrintBalance(IAccount account);
    //    }

    //    public class ConsoleBalancePrinter : IBalancePrinter
    //    {
    //        public void PrintBalance(IAccount account)
    //        {
    //            Console.WriteLine("{0} | {1} | {2} | {3:C}", account.FullName, account.AccountNumber, account.AccountType, account.Balance);
    //        }
    //    }

    //    public interface IDisplay
    //    {
    //        void DisplayMenu();
    //        void DisplayBalance(double balance);
    //        void DisplayTransactionHistory(List<string> history);
    //        void DisplayAccountInfo(IAccount account);
    //    }

    //    public class ConsoleDisplay : IDisplay
    //    {
    //        private readonly IBalancePrinter _balancePrinter;

    //        public ConsoleDisplay(IBalancePrinter balancePrinter)
    //        {
    //            _balancePrinter = balancePrinter;
    //        }

    //        public void DisplayMenu()
    //        {
    //            Console.WriteLine("1. Login");
    //            Console.WriteLine("2. Register");
    //            Console.WriteLine("3. Exit");
    //            Console.WriteLine("4. Print Balance");
    //            Console.WriteLine("5. Print Account Info");
    //        }

    //        public void DisplayBalance(double balance)
    //        {
    //            Console.WriteLine("Your balance is {0:C}", balance);
    //        }

    //        public void DisplayTransactionHistory(List<string> history)
    //        {
    //            foreach (string transaction in history)
    //            {
    //                Console.WriteLine(transaction);
    //            }
    //        }

    //        public void DisplayAccountInfo(IAccount account)
    //        {
    //            _balancePrinter.PrintBalance(account);
    //        }
    //    }

    //    public interface IUserInput
    //    {
    //        int GetChoice();
    //        double GetAmount();
    //        string GetFromAccount();
    //        string GetToAccount();
    //    }

    //    public class ConsoleUserInput : IUserInput
    //    {
    //        public int GetChoice()
    //        {
    //            Console.Write("Enter your choice: ");
    //            return int.Parse(Console.ReadLine());
    //        }

    //        public double GetAmount()
    //        {
    //            Console.Write("Enter the amount: ");
    //            return double.Parse(Console.ReadLine());
    //        }

    //        public string GetFromAccount()
    //        {
    //            Console.Write("Enter the account number to transfer from: ");
    //            return Console.ReadLine();
    //        }

    //        public string GetToAccount()
    //        {
    //            Console.Write("Enter the account number to transfer to: ");
    //            return Console.ReadLine();
    //        }
    //    }

    //    public interface ITransaction
    //    {
    //    }

    //    public class Deposit : ITransaction
    //    {
    //    }

    //    public class Withdrawal : ITransaction
    //    {
    //    }

    //    public class Transfer : ITransaction
    //    {
    //    }

    //    public interface ILoginService
    //    {
    //    }

    //    public class LoginService : ILoginService
    //    {
    //    }

    //    public interface IRegistrationService
    //    {
    //    }

    //    public class RegistrationService : IRegistrationService
    //    {
    //    }
    //}



    //public class BankAccount
    //{
    //    public string AccountNumber { get; set; }
    //    public string AccountType { get; set; }
    //    public string FullName { get; set; }
    //    public decimal Balance { get; set; }



    //    public BankAccount(string accountNumber, string accountType, string fullName, decimal balance)
    //    {
    //        AccountNumber = accountNumber;
    //        AccountType = accountType;
    //        FullName = fullName;
    //        Balance = balance;
    //    }
    //}



    //public class Transaction
    //{
    //    public DateTime Date { get; set; }
    //    public string Description { get; set; }
    //    public decimal Amount { get; set; }
    //    public decimal Balance { get; set; }



    //    public Transaction(DateTime date, string description, decimal amount, decimal balance)
    //    {
    //        Date = date;
    //        Description = description;
    //        Amount = amount;
    //        Balance = balance;
    //    }
    //}



    //public interface IAccountRepository
    //{
    //    void AddAccount(BankAccount account);
    //    BankAccount GetAccountByNumber(string accountNumber);
    //    void AddTransaction(string accountNumber, Transaction transaction);
    //    List<Transaction> GetAccountStatement(string accountNumber);
    //}



    //public class AccountRepository : IAccountRepository
    //{
    //    private Dictionary<string, BankAccount> accounts;
    //    private Dictionary<string, List<Transaction>> accountStatements;



    //    public AccountRepository()
    //    {
    //        accounts = new Dictionary<string, BankAccount>();
    //        accountStatements = new Dictionary<string, List<Transaction>>();
    //    }



    //    public void AddAccount(BankAccount account)
    //    {
    //        accounts.Add(account.AccountNumber, account);
    //        accountStatements.Add(account.AccountNumber, new List<Transaction>());
    //    }



    //    public BankAccount GetAccountByNumber(string accountNumber)
    //    {
    //        if (accounts.ContainsKey(accountNumber))
    //            return accounts[accountNumber];



    //        return null;
    //    }



    //    public void AddTransaction(string accountNumber, Transaction transaction)
    //    {
    //        if (accountStatements.ContainsKey(accountNumber))
    //            accountStatements[accountNumber].Add(transaction);
    //    }



    //    public List<Transaction> GetAccountStatement(string accountNumber)
    //    {
    //        if (accountStatements.ContainsKey(accountNumber))
    //            return accountStatements[accountNumber];



    //        return new List<Transaction>();
    //    }
    //}



    //public class Bank
    //{
    //    private IAccountRepository accountRepository;



    //    public Bank(IAccountRepository accountRepository)
    //    {
    //        this.accountRepository = accountRepository;
    //    }



    //    public void CreateAccount(string accountNumber, string accountType, string fullName, decimal initialDeposit)
    //    {
    //        BankAccount account = new BankAccount(accountNumber, accountType, fullName, initialDeposit);
    //        accountRepository.AddAccount(account);
    //    }



    //    public void Deposit(string accountNumber, decimal amount)
    //    {
    //        BankAccount account = accountRepository.GetAccountByNumber(accountNumber);
    //        if (account != null)
    //        {
    //            account.Balance += amount;
    //            Transaction transaction = new Transaction(DateTime.Now, "Deposit", amount, account.Balance);
    //            accountRepository.AddTransaction(accountNumber, transaction);
    //        }
    //    }



    //    public void Withdraw(string accountNumber, decimal amount)
    //    {
    //        BankAccount account = accountRepository.GetAccountByNumber(accountNumber);
    //        if (account != null)
    //        {
    //            if (account.AccountType == "Savings" && account.Balance - amount < 1000)
    //            {
    //                Console.WriteLine("Withdrawal failed. Minimum balance for a savings account is 1000 Naira.");
    //                return;
    //            }



    //            account.Balance -= amount;
    //            Transaction transaction = new Transaction(DateTime.Now, "Withdrawal", -amount, account.Balance);
    //            accountRepository.AddTransaction(accountNumber, transaction);
    //        }
    //    }



    //    public void DisplayAccountDetails()
    //    {
    //        Console.WriteLine("ACCOUNT DETAILS");
    //        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
    //        Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
    //        Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");



    //        foreach (BankAccount account in accountRepository.GetAccounts())
    //        {
    //            Console.WriteLine($"| {account.FullName,-18} | {account.AccountNumber,-30} | {account.AccountType,-24} | {account.Balance,-19} |");
    //            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
    //        }
    //    }



    //    public void DisplayAccountStatement(string accountNumber)
    //    {
    //        BankAccount account = accountRepository.GetAccountByNumber(accountNumber);
    //        if (account != null)
    //        {
    //            Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NO {accountNumber}");
    //            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
    //            Console.WriteLine("| DATE              | DESCRIPTION                   | AMOUNT                   | BALANCE             |");
    //            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");



    //            List<Transaction> accountStatement = accountRepository.GetAccountStatement(accountNumber);
    //            foreach (Transaction transaction in accountStatement)
    //            {
    //                Console.WriteLine($"| {transaction.Date.ToString("dd/MM/yyyy"),-18} | {transaction.Description,-30} | {transaction.Amount,-24} | {transaction.Balance,-19} |");
    //                Console.WriteLine("|---------------------------------------------------------------------------------------------------|");
    //            }
    //        }
    //    }
    //}



    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        IAccountRepository accountRepository = new AccountRepository();
    //        Bank bank = new Bank(accountRepository);



    //        bank.CreateAccount("0987654321", "Savings", "John Doe", 10000);
    //        bank.CreateAccount("0987654311", "Current", "John Doe", 100000);



    //        bank.Deposit("0987654321", 1000);
    //        bank.Deposit("0987654311", 20000);



    //        bank.Withdraw("0987654321", 500);
    //        bank.Withdraw("0987654311", 50000);



    //        bank.DisplayAccountDetails();
    //        Console.WriteLine();



    //        bank.DisplayAccountStatement("0987654321");
    //        Console.WriteLine();



    //        bank.DisplayAccountStatement("0987654311");
    //    }
    //}
}
