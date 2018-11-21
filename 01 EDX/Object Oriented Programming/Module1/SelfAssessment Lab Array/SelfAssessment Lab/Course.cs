using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfAssessment_Lab
{
    class Course
    {
        // Allow up to 30 students in a course
        static int maxStudents = 30;
        // Allow up to 3 teachers in a course
        static int maxTeachers = 3;

        // Current number of students and teachers in the course
        public int StudentCount { get; private set; }
        public int TeacherCount { get; private set; }

        // Defining properties
        public Teacher[] Teachers { get; set; }
        public Student[] Students { get; set; }

        public Course(Teacher newTeacher)
        {
            // Instantiate the arrays with the max number of people
            Teachers = new Teacher[maxTeachers];
            Students = new Student[maxStudents];

            // Add the first teacher to the course
            Teachers[0] = newTeacher;
        }

        public void addTeacher(Teacher teacher)
        {
            // If we haven't reached the maximum number of teachers, add the new one.
            if (TeacherCount < maxTeachers) 
            { 
                Teachers[TeacherCount] = teacher;
                TeacherCount += 1;
            }
        }

        public void addStudent(Student student)
        {
            // If we haven't reached the maximum number of students, add the new one.
            if (StudentCount < maxStudents) 
            { 
                Students[StudentCount] = student;
                StudentCount += 1;
            }
        }
    }
}
