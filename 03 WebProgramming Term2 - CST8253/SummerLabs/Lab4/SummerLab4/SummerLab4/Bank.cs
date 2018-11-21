using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerLab4
{
    class Bank
    {
        static void Main(string[] args)
        {
            List<SavingAccount> accounts = new List<SavingAccount>();

            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine("Please enter customer name: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    repeat = false;
                    break;
                }
                Console.WriteLine($"Please enter an initial deposit amount for {name}'s saving account (minimum $1.000,00): ");
                double initialDepositAmount = double.Parse(Console.ReadLine());
                Console.WriteLine($"Please enter an monthly deposit amount for {name}'s saving account (minimum $50,00): ");
                double monthlyDepositAmount = double.Parse(Console.ReadLine());

                SavingAccount newAccount = new SavingAccount(name,initialDepositAmount, monthlyDepositAmount);        
                accounts.Add(newAccount);
            }

            int N = accounts.Count();
            for (int i = 0; i < N; i++)
            {
                for (int m = 0; m < 6; m++)
                {
                    accounts[i].Deposit(accounts[i].monthlyDepositAmount);
                    accounts[i].Deposit(accounts[i].balance * accounts[i].monthlyInterestRate);
                    accounts[i].Withdraw(accounts[i].monthlyFee);                    
                }

                Console.WriteLine($"\nAfter 6 months, {accounts[i].owner}'s account (#{accounts[i].accountNumber}) will have a balance of ${accounts[i].balance:C}.");               
            }

            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }
    }
}

