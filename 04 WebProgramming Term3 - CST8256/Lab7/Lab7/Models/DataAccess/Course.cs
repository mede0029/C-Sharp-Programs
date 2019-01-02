using System;
using System.Collections.Generic;

namespace Lab7.Models.DataAccess
{
    public partial class Course
    {
        public Course()
        {
            AcademicRecord = new HashSet<AcademicRecord>();
        }

        public string Code { get; set; }
        public string Title { get; set; }

        public virtual ICollection<AcademicRecord> AcademicRecord { get; set; }
    }
}
