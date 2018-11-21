using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2Solution
{
    public class Student
    {
        public static int MaxNumOfCheckOut = 3;
        public string Name { get; }
        public List<Book> CheckedOutBooks { get; }
        public Student(string name)
        {
            Name = name;
            CheckedOutBooks = new List<Book>();
        }

        public CheckoutResult CheckoutBook(Book book)
        {
            if (CheckedOutBooks.Count == MaxNumOfCheckOut)
                return CheckoutResult.EXCEED_MAX_CHECKOUT;
            
            CheckedOutBooks.Add(book);
            return CheckoutResult.SUCCESS;
        }
    }
}
