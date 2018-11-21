using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CheckingAccount
/// </summary>
public class CheckingAccount : Account
{
    public const double MaxTransferAmount = 300.0;

    public CheckingAccount(Customer customer) : base(customer) { }
    public override TransactionResult Withdraw(Transaction transaction)
    {
        if ( Owner.Status != CustomerStatus.PRIMIER && transaction.Amount > MaxTransferAmount)
        { 
             return TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;
        }
        return base.Withdraw(transaction);
    }
    public override string ToString()
    {
        return "Checking Account - " + string.Format("{0:C2}", Balance);
    }
}