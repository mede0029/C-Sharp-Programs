using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerLab5.Entities;

namespace SummerLab5.Entities
{
    class Customer
    {
        public string Name { get; set; }
        public CustomerStatus Status; 
        public CheckingAccount Checking { get; set; }
        public SavingAccount Saving { get; set; }

        public Customer (string name)
        {
            this.Name = name;
            this.Status = CustomerStatus.REGULAR;
            Checking = new CheckingAccount(this);
            Saving = new SavingAccount(this);
        }
    }    
}
