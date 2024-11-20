using System.Transactions;

public class TransactionHistoryTransaction : Transaction
{
    protected override void PerformTransaction(BankAccount account)
    {
        Console.WriteLine("\nTransaction History:");
        foreach (var transaction in account.TransactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
}
