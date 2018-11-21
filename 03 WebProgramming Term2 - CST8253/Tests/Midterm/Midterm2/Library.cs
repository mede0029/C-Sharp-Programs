using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm2Solution
{
    public class Library
    {
        static void Main(string[] args)
        {
            List<Book> availableBooks = Book.AvailableBooks;
            List<Student> CheckedOutBooks = new List<Student>();            
            string bookSelectionStr;
            int bookSelectionInt;
            double num;

            System.Console.Write("Enter your name: ");
            string name = Console.ReadLine();            
            Student student = new Student(name);
            System.Console.WriteLine();
            System.Console.WriteLine("Welcome {0}! You can check out maximum {1} books:", student.Name, Student.MaxNumOfCheckOut);

            //Write your code here            
            //Displays the list of books:
            for (int i = 0; i < availableBooks.Count; i++) // as long as there is a book in list
            {
                Console.Write("{0}. {1} \n", i, availableBooks[i].Title);
            }
            
            //user chooses the book:
            do
            {
                Console.Write("Enter the book you want to check out: (0 - {0}) or enter -1 to finish: ", availableBooks.Count -1);
                bookSelectionStr = Console.ReadLine();
                
                //breaking out of the loop:
                if (bookSelectionStr == "-1")
                    {                       
                       break;
                    }   
                
                else
                {
                    //validating answer:
                    if ((!double.TryParse(bookSelectionStr, out num)) || (num < -1) || (double.Parse(bookSelectionStr) > availableBooks.Count -1) )
                    {
                        Console.Write("\nNumber is not valid. Please try it again. \n");                        
                        continue;
                    }                     
                    else
                    {
                        //real code:
                        bookSelectionInt = int.Parse(bookSelectionStr);                        
                        //instantiating book:                      
                        Book newBook = availableBooks[bookSelectionInt];
                        CheckoutResult checkedResult = student.CheckoutBook(newBook);
                        
                        if (checkedResult == CheckoutResult.SUCCESS) //book is added to checked out list
                        {                            
                            Console.WriteLine("\nYou have checked out {0}. You can check out {1} more book(s).\n", availableBooks[bookSelectionInt].Title, 3-student.CheckedOutBooks.Count);
                            if (student.CheckedOutBooks.Count == 3)
                            {
                                Console.WriteLine("This was your third (and last) book selected.");
                                break;
                            }
                            else
                            {
                                availableBooks.RemoveAt(bookSelectionInt);
                                for (int i = 0; i < availableBooks.Count; i++) //printing available books list:
                                {
                                    Console.Write("{0}. {1} \n", i, availableBooks[i].Title);
                                }
                            }
                        }                        
                        if (checkedResult == CheckoutResult.EXCEED_MAX_CHECKOUT)
                        {
                            Console.Write("You have exceeded the maximum checkout number. ");
                            break;
                        }      
                    }
                }                        
            } while (bookSelectionStr != "-1");

            //Write your code here
            //Printing checked out list:
            Console.WriteLine("\nYou have checked out the following books:");
            for (int i = 0; i < student.CheckedOutBooks.Count; i++) // as long as there is a book in list
            {
                //Console.WriteLine("why not?");
                Console.Write("{0}. {1} \n", i, student.CheckedOutBooks[i].Title);
            }  
            Console.Write("\nPlease press any key to finish...");
            System.Console.ReadLine();
        }
    }
}
l