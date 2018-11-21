using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.Make = "Chevrolet";
            car1.Model = "Onix";
            car1.VIN = "A1";

            Car car2 = new Car();
            car2.Make = "Fiat";
            car2.Model = "Palio";
            car2.VIN = "A2";

            //You can initialize as a collection, directly:
            Car car3 = new Car() { Make = "BMW", Model = "M4", VIN = "A3" };
            Car car4 = new Car() { Make = "Ford", Model = "EcoSport", VIN = "A4" };

            Book b1 = new Book();
            b1.Author = "Robert Tabor";
            b1.Title = "Microsoft C#";
            b1.ISBN = "0.000.000-00";

            ////ArrayList Old Style, not strongly typed, you could add cars and books:
            //System.Collections.ArrayList myArrayList = new System.Collections.ArrayList();
            //myArrayList.Add(car1);
            //myArrayList.Add(car2);
            //myArrayList.Add(b1);

            //New style = List<T>
            //It's a generic collection that you make it specific, according to types
            List<Car> myList = new List<Car>();
            myList.Add(car1);
            myList.Add(car2);
            myList.Add(car3);
            myList.Add(car4);
            Console.WriteLine("\nLIST:");
            foreach (Car car in myList)
            {
                Console.WriteLine(car.Model);
            }

            //Dictionary: you have an item (unique key) + definition (value)
            //Dictionary<TKey, TValue>
            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>();
            myDictionary.Add(car1.VIN, car1);
            myDictionary.Add(car2.VIN, car2);
            Console.WriteLine("\nDICTIONARY:");
            Console.WriteLine(myDictionary["A2"].Make);

         





            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();



        }
    }

    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }
}
