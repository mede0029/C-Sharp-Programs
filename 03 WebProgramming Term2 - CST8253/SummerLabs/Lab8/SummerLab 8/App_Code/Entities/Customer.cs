using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public CheckingAccount Checking { get; set; }
    public SavingAccount Saving { get; set; }

    private int id;
    public int Id { get { return id; } }

    private string name;
    public string Name { get { return name; } }

    public CustomerStatus Status { get; set; }

    public static List<Customer> GetAllCustomers()
    {
        if (HttpContext.Current.Application["customers"] == null)
        {
            List<Customer> customers = new List<Customer>();

            Customer customer = new Customer(1001, "George W Bush");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(5000.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(1000));
            customers.Add(customer);

            customer = new Customer(1002, "Thomas Mulcair");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(1000.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(1000));
            customers.Add(customer);

            customer = new Customer(1003, "Justin Trudeau");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(50.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(10));
            customers.Add(customer);

            customer = new Customer(1004, "Stephen Harper");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(8000.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(2000));
            customers.Add(customer);

            customer = new Customer(1005, "Andrea Horwath");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(300.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(100));
            customers.Add(customer);

            customer = new Customer(1006, "Kathleen Wynne");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(500.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(200));
            customers.Add(customer);

            customer = new Customer(1007, "John Tory");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(2220.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(220));
            customers.Add(customer);

            customer = new Customer(1008, "Barack Obama");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(50000.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(120));
            customers.Add(customer);

            customer = new Customer(1009, "Vladimir Putin");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(5000000.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(10000000.0));
            customers.Add(customer);

            customer = new Customer(1010, "David Cameron");
            customer.Saving = new SavingAccount(customer);
            customer.Saving.Deposit(new Transaction(500.0));
            customer.Checking = new CheckingAccount(customer);
            customer.Checking.Deposit(new Transaction(60));
            customers.Add(customer);

            HttpContext.Current.Application["customers"] = customers;

            return customers;
        }
        else
        {
            return HttpContext.Current.Application["customers"] as List<Customer>;
        }
    }

    public static Customer GetCustomerById(int id)
    {
        return GetAllCustomers().Where(x => x.Id == id).FirstOrDefault<Customer>();
    }
    public Customer(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public override string ToString()
    {
        return Id.ToString() + " - " + name;
    }
}