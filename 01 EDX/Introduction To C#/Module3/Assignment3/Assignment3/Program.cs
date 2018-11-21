using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {

        static void Main(string[] args)
        {
            //From within Main(), call each of the methods to prompt for input from a user of your application.
            string firstName = "a";
            string lastName = "b";
            string birthday = "c";
            string teacherName = "d";
            string courseName = "e";
            string programName = "f";
            
            GetStudentInformation(out firstName, out lastName, out birthday, out teacherName, out courseName, out programName);
            PrintStudentDetails(firstName, lastName, birthday);
            PrintCourseDetails(programName, courseName, teacherName);

            validatingBirthday();

            Console.WriteLine("Press any key to finish...");
            Console.ReadLine();

        }
        static void GetStudentInformation(out string firstName, out string lastName, out string birthday, out string teacherName, out string courseName, out string programName)
        {
            Console.WriteLine("Enter the student's first name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter the student's last name");
            lastName = Console.ReadLine();
            // Create a method to get information for a teacher, a course, a program, and a degree using a similar method as above:
            Console.WriteLine("What's your birthday? ");
            birthday = Console.ReadLine();
            Console.WriteLine("Enter the name of your teacher: ");
            teacherName = Console.ReadLine();
            Console.WriteLine("Enter the name of your course: ");
            courseName = Console.ReadLine();
            Console.WriteLine("What's the program you're enrolled in? ");
            programName = Console.ReadLine();
        }
        
        //Create methods to print the information to the screen for each object such as static void PrintStudentDetails(...).
        static void PrintStudentDetails(string first, string last, string birthday)
        {
            Console.WriteLine("\n{0} {1} was born on: {2}", first, last, birthday);
        }
        static void PrintCourseDetails(string program, string course, string teacher)
        {
            Console.WriteLine("He/she is enrolled at the {0} program, under the {1} course and the teacher is {2}", program, course, teacher);
        }

        static void validatingBirthday()
        {
            throw new NotImplementedException();
        }


    }
}
