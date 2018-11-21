using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld();

            Console.WriteLine("Press any key to finish...");
            Console.ReadLine();
        }

        public static void HelloWorld()
        {
            Console.WriteLine("Hello world!");
        }

    }
}
