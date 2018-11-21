<%@ Application Language="C#" %>
<%@ Import Namespace="StudentRecordDal"%>
<%@ Import Namespace="System.Web.Security"%>
<script runat="server">
    public void Application_AuthenticateRequest(Object src, EventArgs e)
    {
        if (User != null && User.Identity.AuthenticationType == "Forms" && User.Identity.IsAuthenticated)
        {
           FormsIdentity id = (FormsIdentity)User.Identity;
           int employeeId = int.Parse(id.Name);

           using (StudentRecordEntities entityContext 
                               = new StudentRecordEntities())
           {
              var employee = (from em in entityContext.Employees
                                where em.Id == employeeId
                                select em).FirstOrDefault<Employee>();

              String[] roles = new string[employee.Roles.Count];
              int i = 0;
              foreach (Role r in employee.Roles) {
                 roles[i++] = r.Role1.Trim().ToUpper();
           }
           HttpContext.Current.User = new 
		System.Security.Principal.GenericPrincipal(id, roles);
            }
        }
    }
</script>
