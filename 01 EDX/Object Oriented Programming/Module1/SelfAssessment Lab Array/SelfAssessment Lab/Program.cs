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
            UProgram UProgram1 = new UProgram();
            UProgram1.Course = "Information Technology";

            //Instantiate a Degree object, such as Bachelor, insude the UProgram object.
            UProgram1.Degree = "Bachelor";

            //Instantiate a Course object called Programming with C# inside the Degree object.
            Degree Degree1 = new Degree();
            Degree1.Course = "Programing with C#";

            //Instantiate the course with a primary Teacher
            Teacher teacher = new Teacher("Bob");
            Course Course1 = new Course(teacher);


            // Create a student object to reuse for adding students
            Student student;

            // Add 3 students to the course
            student = new Student("George");
            Course1.addStudent(student);

            student = new Student("Frank");
            Course1.addStudent(student);

            student = new Student("Sandra");
            Course1.addStudent(student);



            //counting students
            int studentCount = Course1.StudentCount;

            //Output:
            Console.WriteLine("The name of the program is {0}, which offers the {1} degree.", UProgram1.Course, UProgram1.Degree);
            Console.WriteLine("\nThe name of the course in the degree is {0}.", Degree1.Course);
            Console.WriteLine("\nThe teacher of the first course is {0}.", Course1.Teachers[0].Name);
            Console.WriteLine("\nThe first student is {0} ", Course1.Students[0].Name);
            Console.WriteLine("\nThere are {0} students in the course.", Course1.StudentCount);
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }
    }
}
