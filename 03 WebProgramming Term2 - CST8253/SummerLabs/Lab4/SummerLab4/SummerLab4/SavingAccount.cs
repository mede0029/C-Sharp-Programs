using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerLab4
{
    class SavingAccount
    {
        
        public string owner { get; set; }
        public double balance { get; set; }
        public double monthlyFee = 4.0;
        public double monthlyInterestRate = 0.0025;
        public double minimumInitialBalance = 1000;
        public double minimumMonthlyDeposit = 50;
        public int accountNumber;
        public double monthlyDepositAmount;

        public SavingAccount (string Name, double InitialDepositAmount, double MontlyDepositAmount)
        {
            this.owner = Name;
            this.balance = InitialDepositAmount;
            this.monthlyDepositAmount = MontlyDepositAmount;
            Random rnd = new Random();
            accountNumber = rnd.Next(90000, 99999); // creates a number between 90000 and 99999
        }

        public void Deposit(double Amount)
        {
            balance = balance + Amount;
        }

        public void Withdraw(double Amount)
        {
            balance = balance - Amount;
        }

    }
}


