using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegistrationEF;

public partial class CurrentRegistrations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Redirect unauthenticated user to the Default page.
        if (Session["studentName"] == null)
        {
            Response.Redirect("Default.aspx");     
        }
        else
        {
            using (RegistrationDB entityContext = new RegistrationDB())
            {
                //showing the list of courses
                List<Course> courses = entityContext.Courses.ToList<Course>(); //existing list of all courses
                List<Course> filteredCourses = new List<Course>(); //new empty list
                foreach (Course course in courses) //loops through each course
                {
                    foreach (Student st in course.Students) //loops through each course to see which students are related to it
                                                            //refer to diagram for navigation properties, that links both tables together
                    {
                        if (st.Name == (string)Session["studentName"]) //select the courses where studentName == the student's name from first page
                        {
                            filteredCourses.Add(course); //add selected courses to the new list "filteredCourses"
                        }
                    }                    
                }
                ShowCourseInfo(filteredCourses); //calling the method to display courses

                //deleting course
                string action = Request.Params["action"];
                string courseId = Request.Params["id"];
                string stNumber = (string)Session["studentNumber"];
                if (Request.Params["action"] == "delete")
                {
                    var removeCourse = (from c in entityContext.Courses
                                  where c.CourseID == courseId
                                  select c).FirstOrDefault<Course>(); //selecting course by id
                    if (removeCourse != null)
                    {
                        for (int i = courses.Count() - 1; i >= 0; i--) //removing from list
                        {
                            var ar = courses.ElementAt<Course>(i);
                            courses.Remove(ar);
                        } 
                    }
                    entityContext.Courses.Remove(removeCourse); //removing from database
                    entityContext.SaveChanges();
                    Response.Redirect("CurrentRegistrations.aspx");
                }
            }
        }
        
        //Get the Home LinkButton on the Master page         
        //make it visible and attach an event handler 
        //so that when clicked, redirect the user to the Default page
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome"); //instanciating Home Button    
        btnHome.Visible = true; //making it visible     
        btnHome.Click += (s, a) => Response.Redirect("Default.aspx"); //adding action to Home Button

        //Get the Logout LinkButton on the Master page
        //make it visible and attach the event handler Logout to it        
        LinkButton btnLogout = (LinkButton)Master.FindControl("btnLogout"); //instanciating Logout Button                
        btnLogout.Visible = true; //making it visible         
        btnLogout.Click += (s, a) => Logout(s, a); //ading an action to Logout button
    }

    protected void Logout(object sender, EventArgs e)
    {
        //Clear session and redirect the user to the Default page.
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }

    private void ShowCourseInfo(List<Course> courses)
    {
        if (courses == null || courses.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "You have not registered any course yet";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblCourses.Rows.Add(lastRow);
        }
        else
        {
            foreach (Course course in courses)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = course.CourseID;
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = course.CourseTitle;
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = course.HoursPerWeek.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "<a class='deleteRegistration' href='CurrentRegistrations.aspx?action=delete&id=" + course.CourseID + "'>Delete</a>";
                row.Cells.Add(cell);
                tblCourses.Rows.Add(row);
            }
        }
    }
}