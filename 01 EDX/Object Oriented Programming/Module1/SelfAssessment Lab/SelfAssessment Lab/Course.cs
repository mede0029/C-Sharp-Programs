using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfAssessment_Lab
{
    class Course
    {
        // Defining properties
        public string Student { get; set; }
        public string Teacher { get; set; }

        private static int instances = 0;

        public Course(string student)
        {
            this.Student = student;
            instances++;
        }

        public static int CountStudents()
        {
            return instances;
        }
    }
}
