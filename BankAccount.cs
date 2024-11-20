using System.Collections.Generic;

public class BankAccount
{
    public int AccountNumber { get; }
    public string Password { get; }
    public string AccountHolderName { get; }
    public double Balance { get; private set; }
    public double InterestRate { get; } = 3.0; // Fixed interest rate
    public List<string> TransactionHistory { get; } = new List<string>();

    public BankAccount(int accountNumber, string password, string accountHolderName, double initialBalance)
    {
        AccountNumber = accountNumber;
        Password = password;
        AccountHolderName = accountHolderName;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        Balance += amount;
        TransactionHistory.Add($"Deposited: ${amount}");
    }

    public bool Withdraw(double amount)
    {
        if (amount > Balance)
        {
            return false;
        }
        Balance -= amount;
        TransactionHistory.Add($"Withdrew: ${amount}");
        return true;
    }
}
