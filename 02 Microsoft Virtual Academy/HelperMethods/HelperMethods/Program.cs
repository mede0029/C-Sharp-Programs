using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Name Game");

            Console.Write("What's your first name? ");
            string firstName = Console.ReadLine();

            Console.Write("What's your last name? ");
            string lastName = Console.ReadLine();

            Console.Write("In what city were you born? ");
            string city = Console.ReadLine();

            Console.Write("Results: ");

            DisplayResult(ReverseThings(firstName), ReverseThings(lastName), ReverseThings(city));

            Console.WriteLine("\nPress any key to finish... ");
            Console.ReadLine();

        }

        public static string ReverseThings(string message)
        {   
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            return String.Concat(messageArray);
        }

        public static void DisplayResult(string reversedFirstName, string reversedLastName, string reversedCity) 
        {
            Console.Write(String.Format("{0} {1} {2}", reversedFirstName, reversedLastName, reversedCity));
        }
    

    }
}
