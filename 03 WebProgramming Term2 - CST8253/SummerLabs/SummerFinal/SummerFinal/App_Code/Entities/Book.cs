using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

public class Book
{
    private static List<Book> allBooks
    {
        get
        {
            List<Book> books = new List<Book>();
            Book book = new Book("0001", "Object Oriented Programming in C#");
            book.Description = "This article gives you an overview of programming with ASP.NET Web Pages using the Razor syntax. ASP.NET is Microsoft's technology for running dynamic web pages on web servers. This articles focuses on using the C# programming language.";
            books.Add(book);

            book = new Book("0002", "Web Programming in PHP");
            book.Description = "The PHP development team announces the immediate availability of PHP 5.6.0beta1. This release adds new features and fixes bugs and marks the feature freeze for the PHP 5.6.0 release. All users of PHP are encouraged to test this version carefully, and report any bugs in the bug tracking system.";
            books.Add(book);

            book = new Book("0003", "Java Programming in 21 Days");
            book.Description = "The Java Tutorials are practical guides for programmers who want to use the Java programming language to create applications. They include hundreds of complete, working examples, and dozens of lessons. Groups of related lessons are organized into trails";
            books.Add(book);

            book = new Book("0004", "Advanced Database Topics");
            book.Description = "The goal of the course is to introduce students to modern database and data management systems. The course will be focused on efficient query processing and indexing techniques for spatial, temporal and multimedia databases. Another topic that will be covered is the analysis of large datasets (data mining). In particular, efficient and scalable algorithms for clustering, association rule discovery and classification of very large datasets will be discussed.";
            books.Add(book);

            book = new Book("0005", "PHP Web Application Development");
            book.Description = "Updated to teach the most current XML standards, this book uses real-world case studies and a practical, step-by-step approach to teach XML. It provides extensive coverage of DTDs, namespaces, schemas, Cascading Style Sheets, XSLT, XPath, and programming with the WSC document object model.";
            books.Add(book);

            book = new Book("0006", "Professional ASP.NET MVC Programming");
            book.Description = "All managed languages in the .NET Framework, such as Visual Basic and C#, provide full support for object-oriented programming including encapsulation, inheritance, and polymorphism. Encapsulation means that a group of related properties, methods, and other members are treated as a single unit or object. Inheritance describes the ability to create new classes based on an existing class.";
            books.Add(book);

            book = new Book("0007", "Professional ASP.NET Core MVC");
            book.Description = "Microsoft insiders join giants of the software development community to offer this in-depth guide to ASP.NET MVC, an essential web development technology.";
            books.Add(book);

            book = new Book("0008", "JavaScript Web Programming");
            book.Description = "This book is a step-by-step. Each chapter contains a friendly mix of theory and practice. You'll be coding your first AJAX application at the end of the first chapter, and with each new chapter you'll develop increasingly complex AJAX applications featuring advanced techniques and coding patterns.AJAX and PHP:  coding patterns and techniques and be able to assess the security and SEO implications of their code";
            books.Add(book);

            book = new Book("0009", "Professional JQuery");
            book.Description = "This book begins by showing you the basics of the XML language. Then, by building on that knowledge, additional and supporting languages and systems will be discussed. To get the most out of this book, you should be somewhat familiar with HTML, although you doneed to be an expert coder by any stretch. No other previous knowledge is required.";
            books.Add(book);

            return books;
        }
    }
    public static List<Book> AvailableBooks
    {
        get
        {
            List<Book> availableBooks = HttpContext.Current.Session["availableBooks"] as List<Book>;
            if (availableBooks == null)
            {
                availableBooks = allBooks;
                HttpContext.Current.Session["availableBooks"] = availableBooks;   
            }
            return availableBooks;
        }
    }

    public static Book GetBookById(string bookId)
    {
        return allBooks.Where(b => b.Id == bookId).FirstOrDefault<Book>();
    }

    public static void MakeBookUnavailable(string bookId)
    {
        AvailableBooks.Remove(AvailableBooks.Where(b => b.Id == bookId).FirstOrDefault<Book>());
    }

    public static void MakeBookAvailable(string bookId)
    {
        AvailableBooks.Add(allBooks.Where(b => b.Id == bookId).FirstOrDefault<Book>());
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public string Id { get; set; }
    private Book(string id, string title)
    {
        Title = title;
        Id = id;
    }

}