using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2Solution
{
    public class Book
    {
        public static List<Book> AvailableBooks
        {
            get
            {
                List<Book> books = new List<Book>();
                Book book = new Book("Object Oriented Programming in C#");
                books.Add(book);

                book = new Book("Web Programming in PHP");
                books.Add(book);

                book = new Book("Java Programming in 21 Days");
                books.Add(book);

                book = new Book("Advanced Database Topics");
                books.Add(book);

                book = new Book("PHP Web Application Development");
                books.Add(book);

                book = new Book("Professional ASP.NET MVC Programming");
                books.Add(book);

                book = new Book("Professional ASP.NET Core MVC");
                books.Add(book);

                book = new Book("JavaScript Web Programming");
                books.Add(book);

                book = new Book("Professional JQuery");
                books.Add(book);

                return books;
            }
        }

        public string Title; //{ get;  }

        public Book(string title)
        {
            Title = title;
        }
    }
}
