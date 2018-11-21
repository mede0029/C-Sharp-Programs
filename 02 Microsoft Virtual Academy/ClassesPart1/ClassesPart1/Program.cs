using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesPart1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Make = "Chevrolet";
            myCar.Model = "Onix";
            myCar.Year = 2013;
            myCar.Color = "silver";

            decimal value = DetermineMaketValue(myCar);            
            Console.WriteLine("The make of my car is {0}, the model of my car is {1}, the year of my car is {2} and the color of my car is {3}.", myCar.Make, myCar.Model, myCar.Year, myCar.Color);
            Console.WriteLine("\nInside the main class, the value of my car is {0:C}.", value);
            Console.WriteLine("But, in Car class, the value of my car is {0:C}", myCar.DetermineMaketValue1());
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }

        //creating a method (outside main, but in class program):
        private static decimal DetermineMaketValue(Car car)
        {
            decimal carValue = 100.0M;
            return carValue;
        }        
    }

    class Car
    {
        //prop + tab + tab to define properties:
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        //creating a method inside Car class
        public decimal DetermineMaketValue1()
        {
            decimal carValue;
            if (Year > 1990)
            {
                carValue = 10000;
            }
            else
            {
                carValue = 2000;
            }
            return carValue;
        }
    }
}
