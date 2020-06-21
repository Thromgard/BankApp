using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp
{
    class Account
    {

        private static int NextAccountNumber = 1;
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; } = 0;
        public string Description { get; set; }

        private static Account[] Accounts = new Account[5];
        private static int NextIndex = 0;

        public static void AddAccount(Account account)
        {
            Accounts[NextIndex] = account;
            NextIndex++;
        }

        public static void ListAccount()
        {
            for(var idx = 0; idx < NextIndex; idx++)
            {
                var account = Accounts[idx];
                Console.WriteLine($"Id:{account.AccountNumber}; Desc:{account.Description}; Bal:{account.GetBalance()}");
            }
        }

        public bool Transfer(Account ToAccount, double Amount)
        {
            var success = Withdraw(Amount);
            if(!success)
            {
                Console.WriteLine("Transfer failed - See log file");
                return false;
            }
            success = ToAccount.Deposit(Amount);
            if(!success)
            {
                Console.WriteLine("Transer failed - See log file");
                Deposit(Amount);
                return false;
            }
            return true;
        }

        public bool Deposit(double Amount)
        {
            if(Amount <= 0)
            {

                Console.WriteLine("Must deposit sufficient funds");
                return false;

            }
            Balance += Amount;
            return true;

        }

        public bool Withdraw(double Amount)
        {

            if (Amount < 0)
            {
                Console.WriteLine("Invalid entry");
                return false;
            }


            if (Amount > Balance)
            {

                Console.WriteLine("insufficient funds");
                return false;

            }



            Balance -= Amount;
            return true;

        }

        public double GetBalance()
        {

            return Balance;


        }
        public static string GetRoutingNumber()
        {
            return "Macho Man Randy Savage";
        }

        public Account()
        {

            this.Description = "New Account";
            this.AccountNumber = NextAccountNumber++;

        }





    }
}
