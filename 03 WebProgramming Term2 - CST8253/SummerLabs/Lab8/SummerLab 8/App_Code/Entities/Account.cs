using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
    private double balance;
    public double Balance { get { return balance; } }

    private Customer owner;
    public Customer Owner {get{return owner;}}

    public Account()
    {
        balance = 0.0;
    }
    public Account(Customer owner)
    {
        this.owner = owner;
    }
    public virtual TransactionResult Deposit(Transaction transaction)
    {
        balance += transaction.Amount;
        return TransactionResult.SUCCESS;
    }

    public virtual TransactionResult Withdraw(Transaction transaction)
    {
        if (transaction.Amount > this.balance)
        {
            return TransactionResult.INSUFFICIENT_FUND;
        }
        balance -= transaction.Amount;
        
        return TransactionResult.SUCCESS;
    }
}