using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
 
    // Declaring the Car() Class
    // This class has 3 properties: Color, Year, and Mileage
    public class Car
    {
        // Defining properties
        public string Color { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }

        //creates integer variable called "instances" and assigns falue to 0
        private static int instances = 0;

        //Adding a constructor
        //This constructor instantiates a Car() object while only having the car's color and year information available
        public Car(string color, int year)
        {
            this.Color = color;
            this.Year = year;
            //Everytime the constructor runs, increment "instances"
            instances++;
        }

        //Adding another constructor
        //This constructor initiates a Car() object while only having the car's year and mileage information available
        public Car(int year, int mileage)
        {
            this.Year = year;
            this.Mileage = mileage;
            //Everytime the constructor runs, increment "instances"
            instances++;
        }

        public Car()
        {
            //Everytime the constructor runs, increment "instances"
            instances++;
        }

        //Declare static member
        public static int CountCars()
        {
            return instances;
        }        
    }
}
