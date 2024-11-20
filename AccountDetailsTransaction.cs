using System.Transactions;

public class AccountDetailsTransaction : Transaction
{
    protected override void PerformTransaction(BankAccount account)
    {
        object value = account.DisplayDetails(); // Display account details
    }
}


