using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab7.Models.DataAccess;

namespace Lab7.Models.ViewModels
{
    public class EmployeeRoleSelections
    {
        public Employee employee { get; set; }

        public List<RoleSelection> roleSelections { get; set; }
        public EmployeeRoleSelections()
        {
            employee = new Employee();
            roleSelections = new List<RoleSelection>();
            StudentRecordContext context = new StudentRecordContext();
            foreach (Role role in context.Role)
            {
                RoleSelection roleSelection = new RoleSelection(role);
                roleSelections.Add(roleSelection);
            }
        }
    }
}
