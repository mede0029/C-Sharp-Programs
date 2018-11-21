using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDX_Module2
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            // *** NUMBER 1: using if statements
            // create an if decision block
            // use this if block to check for an even number
            // Request user input with ReadLine()
            Console.WriteLine("*** NUMBER 1: using if statements ***");
            Console.WriteLine("Please enter an integer value and press Enter.");
            // Assign the entered value to the variable input
            // convert input to integer before using
            int input = Int32.Parse(Console.ReadLine());
            // Check to see if the number is even.
            // Here we use the simple task of checking for a remainder when dividing by 2
            // The (%) or modulus operator returns the remainder of integer devision.
            // If the remainder is 0, then the value is able to be divided by 2 with
            // no remainder, which means it is an even number.
            if (input % 2 == 0)
            {
                Console.WriteLine("The entered number is an even number");
            }
            else
            {
                Console.WriteLine("The entered number is an odd number");
            }


            // *** NUMBER 2: using switch statements
            // Create a switch block
            Console.WriteLine("\n*** NUMBER 2: using switch statements ***");
            Console.WriteLine("Coffee sizes: 1=small 2=medium 3=large");
            Console.Write("Plase enter your selection: ");
            string str = Console.ReadLine();
            int cost = 0;
            switch (str)
            {
                case "1":
                case "small":
                    cost += 25;
                    break;
                case "2":
                case "medium":
                    cost += 50;
                    break;
                case "3":
                case "large":
                    cost += 75;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
                    break;
            }
            if (cost != 0)
            {
                Console.WriteLine("Please insert {0} cents", cost);
            }
            Console.WriteLine("Thank you for your business.");
            
            
            // ***NUMBER 3: using for loop 
            // Create a simple for loop that displays the values of the counter
            // The WriteLine method here demonstrates the use of string interpolation in C#
            // as a way of outputting literal string values with variable values.
            // It is the recommended way to deal with this method of string output
            Console.WriteLine("\n*** NUMBER 3: using if statements ***");
            for (int counter = 0; counter < 10; counter++)
            {
                Console.WriteLine($"Counter is at: {counter}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            
            // ***NUMBER 4: find a prime number
            // Create a nested for loop
            // This sample uses a nested loop to find prime numbers less than 100
            Console.WriteLine("\n*** NUMBER 4: find a prime number ***");
            int outer;
            int inner;
            for (outer = 2; outer < 100; outer++)
            {
                for (inner = 2; inner <= (outer / inner); inner++)
                    if ((outer % inner) == 0)
                        break;
                if (inner > (outer / inner))
                    Console.WriteLine("{0} is prime", outer);
             }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            // *** NUMBER 5: While loop
            // We start with n = 1
            // The condition check for the while, tests if n is less than 6, if so, the loop body code executes
            // inside the loop, we output the value of n and then increment it by 1
            // Once n = 6, the loop stops
            // Pay attention to the output to see what the last value is to ensure you understand
            // how the evaluation of the condition is done and how the while loop executes
            Console.WriteLine("\n*** NUMBER 5: while loop ***");
            int n = 1;
            while (n < 6)
            {
                Console.WriteLine($"Current value of n is {n}");
                n++;
            }
            
            
            // *** NUMBER 6: Do while loop
            // Create a do loop, also known as a do..while loop
            // Note that with the do loop, the loop will run at least once regardless of the value of x
            // which is due to the condition not being checked until the end.
            // Experiment with this by setting x to a value greater than 5 and run the code
            Console.WriteLine("\n*** NUMBER 6: Do while loop ***");
            int x = 0;
            do
            {
                Console.WriteLine(x);
                x++;
            } while (x < 5);
            Console.WriteLine("Press any key to finish...");
            Console.ReadLine();
        }
    }
}
