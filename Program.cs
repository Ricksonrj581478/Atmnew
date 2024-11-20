using System;

class Program
{
    static void Main(string[] args)
    {
        ATMService atmService = new ATMService();
        Console.WriteLine("Welcome to the ATM!");

        // Login process
        Console.Write("Enter Account Number: ");
        int accountNumber = int.Parse(Console.ReadLine());

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        BankAccount account = atmService.Authenticate(accountNumber, password);
        if (account == null)
        {
            Console.WriteLine("Invalid account number or password. Exiting...");
            return;
        }

        Console.WriteLine($"Welcome, {account.AccountHolderName}!");

        // Menu loop
        while (true)
        {
            atmService.ShowMenu();

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            if (choice == "5")
            {
                Console.WriteLine("Thank you for using our ATM. Goodbye!");
                break;
            }

            // Execute transaction based on user input (Polymorphism in action)
            atmService.ExecuteTransaction(choice, account);
        }
    }
}
