using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //student information:           
            string stFirstName = "";
            Console.Write("What's your first name? ");
            stFirstName = Console.ReadLine();

            string stLastName = "";
            Console.Write("What's your last name? ");
            stLastName = Console.ReadLine();

            string stBirthDate = "";
            Console.Write("What's your date of birth? (Enter format mm/dd/yyyy): ");
            stBirthDate = Console.ReadLine();

            string stAddressLine1 = "";
            Console.Write("What's your address? (line1): ");
            stAddressLine1 = Console.ReadLine();

            string stAddressLine2 = "";
            Console.Write("What's your address? (line2): ");
            stAddressLine2 = Console.ReadLine();

            string stCity = "";
            Console.Write("What's your city? ");
            stCity = Console.ReadLine();

            string stState = "";
            Console.Write("What's your state/province? ");
            stState = Console.ReadLine();

            string stPostalCode = "";
            Console.Write("What's your postal code? ");
            stPostalCode = Console.ReadLine();

            string stCountry = "";
            Console.Write("What's your country? ");
            stCountry = Console.ReadLine();

            // teacher information:
            string tcFirstName = "John";
            string tcLastName = "Martin";
            DateTime tcBirthDate = new DateTime(1932, 6, 1);
            string tcAddressLine1 = "235 Interunion Dr";
            string tcAddressLine2 = "Gloucester";
            string tcCity = "Oaklahoma City";
            string tcState = "Oaklahoma";
            string tcPostalCode = "K2J5X1";
            string tcCountry = "USA";

            // program information:
            string progName = "Mobile Technology";
            string deptHead = "Tesla";
            string degrees = "Bachelor";

            // degree information:
            string degreeName = "Programmer";
            string creditsRequired = "45";

            // course information:
            string courseName = "Internet Application And Web Development";
            string credits = "45";
            int durationWeeks = 48;
            string teacher = "Edgar Allan Poe";

            // output values:
            Console.WriteLine("\nSudent's name: {0} {1}", stFirstName, stLastName);
            Console.WriteLine("Student's address: {0}, {1}", stAddressLine1, stAddressLine2);
            Console.WriteLine("City: {0} - State/Province: {1} - Postal Code: {2} - Country: {3}", stCity, stState, stPostalCode, stCountry);
            Console.WriteLine("Student's birthdate: {0}", stBirthDate);

            Console.WriteLine("\nTeacher's name: {0} {1}", tcFirstName, tcLastName);
            Console.WriteLine("Teacher's address: {0}, {1}", tcAddressLine1, tcAddressLine2);
            Console.WriteLine("City: {0} - State/Province: {1} - Postal Code: {2} - Country: {3}", tcCity, tcState, tcPostalCode, tcCountry);
            Console.WriteLine("Teacher's birthdate: {0}", tcBirthDate);

            Console.WriteLine("\nPrograme name: {0}", progName);
            Console.WriteLine("Department head: {0}", deptHead);
            Console.WriteLine("Degree: {0}", degrees);

            Console.WriteLine("\nDegree name: {0}", degreeName);
            Console.WriteLine("Programe name: {0}", progName);
            Console.WriteLine("Credits required: {0}", creditsRequired);
            Console.WriteLine("Course name: {0}", courseName);
            Console.WriteLine("Credits: {0}", credits);
            Console.WriteLine("Duration in weeks: {0}", durationWeeks);
            Console.WriteLine("Teacher: {0}", teacher);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }
    }
}
