using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDX_Module3
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = Sum(20, 40);
            Console.WriteLine($"Calling Sum() with two arguments, result is: {result}");

            int result3 = Sum(10, 50, 80);
            Console.WriteLine($"Calling Sum() with three arguments, result is: {result3}");

            double dblResult = Sum(20.5, 30.6);
            Console.WriteLine($"Calling Sum() that takes doubles result in: {dblResult}");

            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }

        static int Sum(int first, int second)
        {
            // Sum() method that takes two integer arguments and sums them
            // The method returns no value which is why we use void
            // We also need to use static in the method signature because Main is static
            // and you cannot call a non-static method from a static method
            int sum = first + second;
            return sum;
        }

        static int Sum(int first, int second, int third)
        {
            // Sum() method that takes three integer arguments and sums them
            // and then returns the value
            // This method uses the same name as the Sum() method that takes two integers
            // but the parameters here indicate the method is expecting three integers as arguments
            // The compiler knows which method to call based on the number of arguments passed in
            int sum = first + second + third;
            return sum;
        }

        static double Sum(double first, double second)
        {
            // Sum() method that takes two doubles as arguments
            // This method uses the same name as the Sum() method that takes two integers
            // but the parameters here indicate the method is expecting two doubles as arguments
            // The compiler knows which method to call based on the arguments data types
            double result = first + second;
            return result;
        }
    }
}
