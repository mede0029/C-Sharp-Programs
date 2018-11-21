using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiating an object of Car() Class by using Type Inference called Car1
            var Car1 = new Car();
            // Using dot notation to call members on Car1
            Car1.Color = "White";
            Car1.Year = 2010;
            Car1.Mileage = 11000;

            var Car2 = new Car("Red", 2008);

            //Access static members
            int carCount = Car.CountCars();

            //Output to the console window
            Console.WriteLine($"There are {carCount} cars on inventory right now.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }

     

}
