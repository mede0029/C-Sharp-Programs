using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transaction
/// </summary>
public class TransferTransaction : Transaction
{
    public Account FromAccount { get; set; }
    public Account ToAccount { get; set; }
    public double TransactionAmount { get; set;}

    public TransferTransaction(double amount) : base(amount) { }
    public TransactionResult Execute()
    {
            TransactionResult result = FromAccount.Withdraw(this);
            if (result == TransactionResult.SUCCESS)
            {
                return ToAccount.Deposit(this);
            }
            else
            {
                return result;
            }
    }

}