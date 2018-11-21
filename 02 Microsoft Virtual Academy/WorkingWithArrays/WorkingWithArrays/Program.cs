using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //// *** Creating int arrays 1: ***
            //* int[] numbers = new int[5];
            //numbers[0] = 4;
            //numbers[1] = 8;
            //numbers[2] = 15;
            //numbers[3] = 16;
            //numbers[4] = 23;
            //Console.WriteLine(numbers[1]);
            //Console.WriteLine(numbers.Length);

            //// *** Creating int arrays 2: ***
            //int[] numbers = new int[] { 4, 8, 15, 16, 23, 42 };

            // *** Creating string arrays: ***
            string[] names = new string[] { "Eddie", "Alex", "Michel", "David Lee" };

            //// ***Iterating throught arrays 1: ***
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine(names[i]);
            //}

            //// *** Iterating with arrays 2: ***
            //foreach (string name in names)
            //{
            //    Console.WriteLine(name);
            //}

            // *** Reversing a string by turning it into an array:
            string zig = "You can get what you want out of lfe if you help enought other people to get what they want.";
            char[] charArray = zig.ToCharArray();
            Array.Reverse(charArray);
            foreach (char zigChar in charArray)
            {
                Console.Write(zigChar);
            }




            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
           
        }
    }
}
