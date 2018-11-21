using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelfAssessment_Lab
{
    class Teacher
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int ID { get; set; }

        public Teacher(string name)
        {
            this.Name = name;
        }

        public Teacher(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }

        public Teacher(string name, int id, string phonenumber)
        {
            this.Name = name;
            this.ID = id;
            this.PhoneNumber = phonenumber;
        }
    }
}
