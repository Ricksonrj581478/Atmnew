using System.Transactions;

public class DepositTransaction : Transaction
{
    private double amount;

    public DepositTransaction(double amount)
    {
        this.amount = amount;
    }

    // Constructor with no amount specified, it will ask for the amount at runtime
    public DepositTransaction() { }

    protected override void PerformTransaction(BankAccount account)
    {
        if (amount == 0)
        {
            account.Deposit(); // Ask the user for an amount
        }
        else
        {
            account.Deposit(amount); // Use the specified amount
        }
    }
}
