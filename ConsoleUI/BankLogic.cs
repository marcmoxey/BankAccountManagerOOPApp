using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class BankLogic
    {
        public static void TransferFunds()
        {

        }

        public static void CalculateInterest(AccountModel account)
        {
            // [balance] * [interestRate] * [OneMonth]
            double output = 0;

            output = account.Balance * 0.50 * 0.0083;
           
            double total = Math.Round(account.Balance + output, 2);
            Console.WriteLine($"Your earn ${Math.Round(output,2)} this month on interest. Your${account.Balance} your balance is now {total}");
        }

        public static AccountModel CreateAccount()
        {
            AccountModel account = new AccountModel();
            Console.WriteLine("Create an Account:\n");

            // Ask for user name
            Console.Write("What is your name: ");
            string accountOwner = Console.ReadLine();
            account.OwnerName = accountOwner;

            // Ask user how much they depositing
            Console.Write("How much are you depositing today: ");
            string depositsText = Console.ReadLine();
            double depositsAmount;
            bool isValidDeposits = double.TryParse(depositsText, out depositsAmount);


            while (isValidDeposits == false)
            {
                Console.WriteLine("That was not a valid number. Please try again. ");
                Console.Write("Please enter the amount you would like to deposit today: ");
                depositsText = Console.ReadLine();
                isValidDeposits = double.TryParse(depositsText, out depositsAmount);

            }

            account.Balance = depositsAmount;



            // set bank account #
            Random rand = new Random();
            string nums = "1234567890";
            int MAX_LENGTH = 12;
            string accountNumber = string.Empty;

            for (int i = 0; i < MAX_LENGTH; i++) 
            {

                int tempRand = rand.Next(10);
                accountNumber += nums.ElementAt(tempRand);
                account.AccountNumber = accountNumber;
            }

            Console.WriteLine();
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Balance: ${depositsAmount}");
            Console.WriteLine();

           return account;
            
        }

        public static void Withdraw(AccountModel account)
        {

            if (account.Balance > 0)
            {
                double withdrawAmount;
                Console.Write("How much would you like to withdraw: ");
                string withdrawText = Console.ReadLine();
                bool isValidWithdraw = double.TryParse(withdrawText, out withdrawAmount);
              

                while (isValidWithdraw == false)
                {
                    Console.WriteLine("That was not a valid number. Please try again. ");
                    Console.Write("Please enter the amount you would like to withdraw today: ");
                    withdrawText = Console.ReadLine();
                    isValidWithdraw = double.TryParse(withdrawText, out withdrawAmount);

                }
                account.Balance -= withdrawAmount;
                Console.WriteLine($"You withdrew {withdrawAmount}");
                Console.WriteLine($"Current balance is {account.Balance}");
            } else
            {
                Console.WriteLine("You have no money to withdraw from your account");
            }
        }

        public static void Deposit(AccountModel account)
        {
            double depositAmount;
            Console.Write("How much would you like to deposit today: ");
            string depositText = Console.ReadLine();
            bool isValidDeposit = double.TryParse(depositText, out depositAmount);
            

            while(isValidDeposit == false) 
            {
                Console.WriteLine("That was not a valid number. Please try again. ");
                Console.Write("Please enter the amount you would like to withdraw today: ");
                depositText = Console.ReadLine();
                isValidDeposit = double.TryParse(depositText, out depositAmount);
            }
            account.Balance += depositAmount;
            Console.WriteLine($"You deposit {depositAmount}");
            Console.WriteLine($"Current balance is {account.Balance}");
        }
    }
}
