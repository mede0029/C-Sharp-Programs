using System;
using System.Collections.Generic;

namespace Lab7.Models.DataAccess
{
    public partial class EmployeeRole
    {
        public int EmployeeId { get; set; }
        public int RoleId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}
