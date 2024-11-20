using System;
using System.Collections.Generic;
using System.Transactions;

public class ATMService
{
    private Dictionary<string, Transaction> transactionMap;
    private Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();

    public ATMService()
    {
        // Adding sample account
        accounts[101] = new BankAccount(101, "1234", "Curly Smith", 500);

        // Mapping of user input to transaction
        transactionMap = new Dictionary<string, Transaction>
        {
            { "1", new AccountDetailsTransaction() },
            { "2", new DepositTransaction() },
            { "3", new WithdrawTransaction() },
            { "4", new TransactionHistoryTransaction() }
        };
    }

    public BankAccount Authenticate(int accountNumber, string password)
    {
        if (accounts.ContainsKey(accountNumber) && accounts[accountNumber].Password == password)
        {
            return accounts[accountNumber];
        }
        return null;
    }

    public void ShowMenu()
    {
        Console.WriteLine("\nSelect an option:");
        Console.WriteLine("1. View Account Details");
        Console.WriteLine("2. Deposit Money");
        Console.WriteLine("3. Withdraw Money");
        Console.WriteLine("4. View Transaction History");
        Console.WriteLine("5. Exit");
    }

    public void ExecuteTransaction(string choice, BankAccount account)
    {
        if (transactionMap.ContainsKey(choice))
        {
            transactionMap[choice].Execute(account); // Polymorphic behavior
        }
        else
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
    }
}
