using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDX_Module1
{
    class Program
    {
        static void Main(string[] args)
        {
            // create variable of different data types
            // initialize with a "default" value
            string firstName = "";
            string lastName = "";
            int age = 0;
            string street = "";
            string city = "";
            string country = "";
            DateTime birthDate;

            // Assign some values:
            firstName = "Tom";
            lastName = "Thumb";
            age = 18;
            street = "123 Fourth Street";
            city = "Anytown";
            country = "MyCountry";
            birthDate = new DateTime(1932, 6, 1);

            // output to the console window

            // use simple output with just variable name:
            Console.WriteLine(firstName);
            Console.WriteLine(lastName);

            // use placeholder style:
            Console.WriteLine("{0} years old.", age);

            // use string concatenation:
            Console.WriteLine(street + ", " + city + ", " + country);

            // use strig interpolation
            // NOTE: this line of code only works with Visual Studio 2015 or C# 6.0 and later.
            // If you are using an earlier version, then comment out this line of code:
            Console.WriteLine($"Born on {birthDate}");
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }
    }
}
