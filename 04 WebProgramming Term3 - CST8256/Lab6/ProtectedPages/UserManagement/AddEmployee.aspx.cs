using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRecordDal; 

public partial class AddCourse : BasePage
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e); //loading base page    
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome"); //loading button home from base page 

        //displaying employees list
        using (StudentRecordEntities entityContext = new StudentRecordEntities())
        {
            List<Employee> empList = entityContext.Employees.ToList<Employee>();
            List<Role> roleList = entityContext.Roles.ToList<Role>();

            //displaying checkbox, populating from the database
            if (!IsPostBack)
            {
                foreach (Role role in entityContext.Roles.ToList<Role>())
                {
                    checkBox.Items.Add(new ListItem(role.Role1, role.Id.ToString())); //using name as text(Role1) + role id coming from db as "index" (1, 2, 3)
                }
            }
            
            //displaying table content
            foreach (Employee em in empList) //going through each employee
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = em.Name.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = em.UserName.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                string stRole = "";
                foreach (Role l in em.Roles) //looping through each role of the employee
                {
                    stRole = stRole + "," + l.Role1.ToString(); //adding each role name (Role1) to stRole variable
                }
                stRole = stRole.TrimStart(',');
                cell.Text = stRole;
                row.Cells.Add(cell);
                tableSort.Rows.Add(row);
            }            
        }         
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        //validate checklist
        if (checkBox.SelectedItem == null) //if nothing is selected
        {
            validateCheckList.InnerText = "You must choose at least one role for this employee";
        }
        else //if at least one checkbox is selected, continue code
        {
            validateCheckList.InnerText = "";
            using (StudentRecordEntities entityContext = new StudentRecordEntities())
            {
                //check if emplyee exists
                var employee = (from em in entityContext.Employees
                                where em.UserName == userNameTxt.Text
                                select em).FirstOrDefault<Employee>();

                if (employee != null) //if user name already exists
                {
                    spanUserName.InnerText = "This user name already exists!";
                }
                else //if username doesn't exist, go on with code
                {
                    spanUserName.InnerText = "";
                    
                    //creating employee
                    Employee newEmployee = new Employee();
                    newEmployee.Name = nameTxt.Text;
                    newEmployee.UserName = userNameTxt.Text;
                    newEmployee.Password = passwordTxt.Text;

                    //getting list of roles selected for the employee
                    Role role = null;
                    foreach (ListItem item in checkBox.Items)
                    {
                        if (item.Selected == true) 
                        {
                            int selectedRoleId = int.Parse(item.Value);
                            //looking through role table, comparing role.id with the id of each selected item on chekbox, assingned on foreach loop
                            role = (from r in entityContext.Roles
                                    where r.Id == selectedRoleId
                                    select r).FirstOrDefault<Role>();
                            newEmployee.Roles.Add(role); //for every matching item, add respective role to newEmployee
                        }
                    }
                    entityContext.Employees.Add(newEmployee);
                    entityContext.SaveChanges();
                    Response.Redirect("AddEmployee.aspx");
                }
            }
        }       
    }
}