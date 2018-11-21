using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerLab5.Entities;

namespace SummerLab5.Entities
{
    class Account
    {
        public Customer Owner { get; set; }
        public double Balance { get; set; }
        public List<Transaction> TransactionHistory;

        public Account(Customer customer)
        {
            this.Owner = customer;
            this.Balance = 0.0;
            this.TransactionHistory = new List<Transaction>();
        }

        public virtual void Deposit (Transaction transaction)
        {
            Balance = Balance + transaction.Amount;
            TransactionHistory.Add(transaction);
        }

        public virtual TransactionResult Withdraw (Transaction transaction)
        {
            if (transaction.Amount <= Balance)
            {
                Balance = Balance - transaction.Amount;
                TransactionHistory.Add(transaction);
                return TransactionResult.SUCCESS;
            }
            else
            {
                return TransactionResult.INSUFFICIENT_FUND;
            }
        }

        public virtual TransactionResult TransferOut(Transaction transaction)
        {
            if (transaction.Amount <= Balance)
            {
                Balance = Balance - transaction.Amount;
                TransactionHistory.Add(transaction);
                return TransactionResult.SUCCESS;
            }
            else
            {
                return TransactionResult.INSUFFICIENT_FUND;
            }        
        }
        public virtual void TransferIn(Transaction transaction)
        {
            Balance = Balance + transaction.Amount;
            TransactionHistory.Add(transaction);
        }
    }
}
