using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDX_Module3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = 9;
            int second = 0;
            Console.WriteLine("Enter your first number: ");
            first = System.Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter your second number: ");
            second = System.Int32.Parse(Console.ReadLine());

            int result = Divide(first, second);
            Console.WriteLine($"The result of dividing {first} by {second} is {result}.");

            Console.WriteLine("Press any key to finish...");
            Console.ReadLine();
        }

        static int Divide(int first, int second)
        {
            // Method Divide() accepts two integer arguments and returns the result
            // of dividing first by second
            // We do no validation of the the arguments so a user may pass in a zero
            // in place of the second parameter.   This is an illegal operation in math
            // If we don't validate input or catch the error, the application will crash
            int result = 0;
            try
            {
                result = first / second;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero, please provide a non-zero value for your second value.");
            }
            return result;
        }


    }
}
