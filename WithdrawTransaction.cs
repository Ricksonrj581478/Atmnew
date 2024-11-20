using System.Transactions;

public class WithdrawTransaction : Transaction
{
    private double amount;

    public WithdrawTransaction(double amount)
    {
        this.amount = amount;
    }

    // Constructor with no amount specified, it will ask for the amount at runtime
    public WithdrawTransaction() { }

    protected override void PerformTransaction(BankAccount account)
    {
        if (amount == 0)
        {
            if (!account.Withdraw()) // Ask the user for the withdrawal amount
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
        else
        {
            if (!account.Withdraw(amount)) // Use the specified amount
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
    }
}
