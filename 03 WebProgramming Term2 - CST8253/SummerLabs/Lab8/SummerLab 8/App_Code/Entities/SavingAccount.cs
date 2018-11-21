using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SavingAccount
/// </summary>
public class SavingAccount : Account
{
    public static double PrimierAmount  = 3000.0;

    public SavingAccount(Customer customer) : base(customer)
    {
    }
    public override TransactionResult Deposit(Transaction transaction)
    {
        TransactionResult result = base.Deposit(transaction);
        if (Balance >= PrimierAmount)
        {
            Owner.Status = CustomerStatus.PRIMIER;
        }
        return result;
    }
    public override TransactionResult Withdraw(Transaction transaction)
    {
        TransactionResult result = base.Withdraw(transaction);

        if (result == TransactionResult.SUCCESS)
        {
            if (Balance < PrimierAmount)
            {
                Owner.Status = CustomerStatus.REGULAR;
            }
        }
        return result;
    }

    public override string ToString()
    {
        return "Saving Account - " + string.Format("{0:C2}", Balance);
    }
}