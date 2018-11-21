using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerLab5.Entities
{
    class Transaction
    {
        public double Amount { set; get; }
        public TransactionType Type { set; get; }
        public DateTime TransactionDate { get; set; }

        public Transaction (double amount, TransactionType type)
        {
            this.Amount = amount;
            this.Type = type;
            this.TransactionDate = DateTime.Now;
        }
    }
}
