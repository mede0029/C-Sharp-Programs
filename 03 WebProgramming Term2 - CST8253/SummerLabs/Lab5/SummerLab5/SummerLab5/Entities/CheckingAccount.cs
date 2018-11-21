using SummerLab5.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerLab5.Entities
{
    class CheckingAccount : Account
    {
        public static double MaxWithdrawAmount = 300.0;
        public CheckingAccount(Customer customer) : base(customer) { } //inherit Account constructor instead of writing it over again,
                                                                       //using the same customer (customer) parameter from base class
        public override TransactionResult Withdraw(Transaction transaction)
        {
            if (transaction.Amount >= Balance)
            {
                return TransactionResult.INSUFFICIENT_FUND;
            }
            else
            {
                if (Owner.Status == CustomerStatus.REGULAR && transaction.Amount > MaxWithdrawAmount)
                {
                    return TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;
                }
                else
                {
                    Balance = Balance - transaction.Amount;
                    TransactionHistory.Add(transaction);
                    return TransactionResult.SUCCESS;
                }                    
            }                           
        }
    }
}
