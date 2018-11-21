using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing if a number is prime:
            Console.WriteLine("Choose a max number: ");
            int maxNumber = System.Int32.Parse(Console.ReadLine());
            for (int number = maxNumber; number > 1; number--)
            {
                for (int counter = number - 1; counter > 1; counter--)
                {
                    if (number % counter == 0)
                    {
                        Console.WriteLine($"\nNumber {number} is not prime, because it can be devided at least by {counter}, other than 1 and itself.");
                        break;
                    }
                    else if (number % counter != 00 && counter == 2)
                    {
                        Console.WriteLine($"\nNumber {number} is a prime number.");
                        break;
                    }
                }
            }
            if (maxNumber > 1)
            {
                Console.WriteLine("\nNumber 2 is a prime number.");
            }
            Console.WriteLine("\nNumber 1 is a prime number.");
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }
    }
}
