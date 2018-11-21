using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfAssessment_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate a UProgram object called Information Technology.
            var UProgram1 = new UProgram();
            UProgram1.Course = "Information Technology";

            //Instantiate a Degree object, such as Bachelor, insude the UProgram object.
            UProgram1.Degree = "Bachelor";

            //Instantiate a Course object called Programming with C# inside the Degree object.
            var Degree1 = new Degree();
            Degree1.Course = "Programing with C#";

            //Instantiate your three students in this Course object.
            var Course1 = new Course("John Doe");            
            var Course2 = new Course("Mary Jane");            
            var Course3 = new Course("Bart Simpson");            

            //Instantiate at least one Teacher object in the Course object
            Course1.Teacher = "Homer Simpson";

            //counting students
            int studentCount = Course.CountStudents();

            //Output:
            Console.WriteLine($"The name of the program is {UProgram1.Course}, which offers the {UProgram1.Degree} degree.");
            Console.WriteLine($"\nThe name of the course in the degree is {Degree1.Course}.");
            Console.WriteLine($"\nThe count of the number of students is {studentCount}.");
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }
    }
}
