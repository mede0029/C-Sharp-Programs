using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfAssessment_Lab
{
    class Student
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int ID { get; set; }

        public Student(string name)
        {
            this.Name = name;
        }

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }

        public Student(string name, int id, string phonenumber)
        {
            this.Name = name;
            this.ID = id;
            this.PhoneNumber = phonenumber;
        }

    }

}
