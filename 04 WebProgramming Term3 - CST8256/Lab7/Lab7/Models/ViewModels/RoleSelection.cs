using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab7.Models.DataAccess;

namespace Lab7.Models.ViewModels
{
    public class RoleSelection
    {
        public Role role { get; set; }

        public bool Selected { get; set; }

        public RoleSelection()
        {
            role = null;
            Selected = false;
        }

        public RoleSelection(Role role, bool selected = false)
        {
            this.role = role;
            Selected = selected;
        }
    }
}
