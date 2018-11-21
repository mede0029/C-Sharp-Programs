using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Transaction
{
    public double Amount { get; set; }
    public DateTime TransactionDate { get; set; }

    public Transaction(double amount)
    {
        Amount = amount;
        TransactionDate = DateTime.Now;
    }
}
