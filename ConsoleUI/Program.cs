using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserMessages.WelcomeMessage();
            string userInput;

            // Create Accounts
            AccountModel checkingAccount = new AccountModel();
            checkingAccount = BankLogic.CreateAccount();

            AccountModel savingsAccount = new AccountModel();
            savingsAccount = BankLogic.CreateAccount();

            List<AccountModel> accounts = new List<AccountModel>();
            accounts.Add(checkingAccount);
            accounts.Add(savingsAccount);

            // Display account details
            Console.WriteLine("Accounts created successfully:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}, Owner: {account.OwnerName}, Balance: ${account.Balance}");
            }

            //BankLogic.CalculateInterest(checkingAccount);

      

            Console.ReadLine();
        }
    }
}
