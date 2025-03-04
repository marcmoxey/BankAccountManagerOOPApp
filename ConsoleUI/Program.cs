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
            string userInput = Console.ReadLine();

            // Create Accounts
            AccountModel checkingAccount = new AccountModel();
            checkingAccount = BankLogic.CreateAccount();

            AccountModel savingsAccount = new AccountModel();
            savingsAccount = BankLogic.CreateAccount();

            //BankLogic.CalculateInterest(checkingAccount);

          


            Console.ReadLine();
        }
    }
}
