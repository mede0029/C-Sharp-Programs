using System;
using System.Collections.Generic;

namespace Lab7.Models.DataAccess
{
    public partial class Student
    {
        public Student()
        {
            AcademicRecord = new HashSet<AcademicRecord>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual ICollection<AcademicRecord> AcademicRecord { get; set; }
    }
}
