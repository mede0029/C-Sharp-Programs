using SummerLab5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerLab5
{
    class SavingAccount : Account
    {
        public static double PremierAmount = 2000.0;
        public static double WithdrawPenaltyAmount = 10.0;

        public SavingAccount(Customer customer) : base(customer) { } //inherit Account constructor instead of writing it over again,
                                                                     //using the same customer (customer) parameter from base class

        public override TransactionResult Withdraw(Transaction transaction)
        {
            if (transaction.Amount >= Balance)
            {
                return TransactionResult.INSUFFICIENT_FUND;
            }
            else
            {                
                Balance = Balance - transaction.Amount;
                TransactionHistory.Add(transaction);
                if (Owner.Status == CustomerStatus.REGULAR)
                {
                    Balance = Balance - WithdrawPenaltyAmount;
                    Transaction PENALTY = new Transaction(WithdrawPenaltyAmount,TransactionType.PENALTY);
                    TransactionHistory.Add(PENALTY);
                }
                if (Balance < 2000)
                {
                    Owner.Status = CustomerStatus.REGULAR;
                }
                return TransactionResult.SUCCESS;
            }
        }

        public override TransactionResult TransferOut(Transaction transaction)
        {
            if (transaction.Amount <= Balance)
            {
                Balance = Balance - transaction.Amount;
                TransactionHistory.Add(transaction);
                if (Balance < 2000)
                {
                    Owner.Status = CustomerStatus.REGULAR;
                }
                return TransactionResult.SUCCESS;
            }
            else
            {
                return TransactionResult.INSUFFICIENT_FUND;
            }
        }

        public override void Deposit(Transaction transaction)
        {
            Balance = Balance + transaction.Amount;
            TransactionHistory.Add(transaction);
            if (Balance >= 2000)
            {
                Owner.Status = CustomerStatus.PREMIER;
            }
        }
        public override void TransferIn(Transaction transaction)
        {
            Balance = Balance + transaction.Amount;
            TransactionHistory.Add(transaction);
            if (Balance >= 2000)
            {
                Owner.Status = CustomerStatus.PREMIER;
            }
        }
    }
}
