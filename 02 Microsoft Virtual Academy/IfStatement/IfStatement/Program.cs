using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfStatement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bob's Big Giveaway");
            Console.Write("Choose door 1, 2 or 3: ");
            string choice = Console.ReadLine();
            string message;

            // *** OPTION 1: ***
            //if (choice == "1")
            //{
            //    message = "\nYou won a car!";         
            //}
            //else if (choice == "2")
            //{
            //    message = "\nYou won a boat!";                
            //}
            //else if (choice == "3")
            //{
            //    message = "\nYou won a new cat!";                
            //}
            //else
            //{
            //    message = "\nSorry, we didn't understand. ";
            //    message += "You lose!";
            //}
            //Console.WriteLine(message);

            // *** OPTION 2: ***
            message = (choice == "1") ? "boat": "strand of tint";
            Console.Write($"You won a {message}!");

            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        
        }
    }
}
