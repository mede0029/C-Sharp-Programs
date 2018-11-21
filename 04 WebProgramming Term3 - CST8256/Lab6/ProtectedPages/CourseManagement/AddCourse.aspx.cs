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

        // listing items from database when page loads
        using (StudentRecordEntities entityContext = new StudentRecordEntities())
        {
            List<Course> courses = entityContext.Courses.ToList<Course>();
            string action = Request.Params["action"];
            string courseCode = Request.Params["id"];
            if (!IsPostBack)
            {
                spanNumber.InnerText = " ";
                foreach (Course c in courses)
                {
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    cell.Text = c.Code.ToString();
                    row.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = c.Title.ToString();
                    row.Cells.Add(cell);
                    cell = new TableCell();
                    cell.Text = "<a href='AddCourse.aspx?action=edit&id=" + c.Code + "'>Edit</a>" + " | " +
                            "<a class='deleteCourse' href='AddCourse.aspx?action=delete&id=" + c.Code + " '>Delete</a>";
                    row.Cells.Add(cell);
                    tableSort.Rows.Add(row);
                }        
                
                //displaying fields when user clicks Edit        
                if (Request.Params["action"] == "edit") //if action = edit
                {
                    var course = (from c in entityContext.Courses
                                  where c.Code == courseCode
                                  select c).FirstOrDefault<Course>();
                    if (course != null)
                    {
                        courseNameTxt.Text = course.Title;
                        courseNumberTxt.Text = course.Code;
                        courseNumberTxt.Enabled = false;
                    }
                }

                //deleting records
                if (Request.Params["action"] == "delete")
                {
                    var course = (from c in entityContext.Courses
                                  where c.Code == courseCode
                                  select c).FirstOrDefault<Course>();
                    if (course != null)
                    {
                        for (int i = course.AcademicRecords.Count() - 1; i >= 0; i--)
                        {
                            var ar = course.AcademicRecords.ElementAt<AcademicRecord>(i);
                            course.AcademicRecords.Remove(ar);
                        }
                    }
                    entityContext.Courses.Remove(course);
                    entityContext.SaveChanges();
                    Response.Redirect("AddCourse.aspx");
                }
            }            
        }
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        using (StudentRecordEntities entityContext
            = new StudentRecordEntities())
        {
            List<Course> courses = entityContext.Courses.ToList<Course>();

            //check if course already exists
            var course = (from c in entityContext.Courses
                          where c.Code == courseNumberTxt.Text 
                          select c).FirstOrDefault();
            
            if (course == null) //if course number doesn't exist = create a new course
            {
                //create course and add to database
                string courseCode = courseNumberTxt.Text;
                string courseTitle = courseNameTxt.Text;
                Course course1 = new Course();
                course1.Code = courseCode;
                course1.Title = courseTitle;
                entityContext.Courses.Add(course1);
                entityContext.SaveChanges();

                //coming back to home page to display courses from updated database
                courseNumberTxt.Text = "";
                courseNameTxt.Text = "";
                Response.Redirect("AddCourse.aspx");
            }
            else //if number exists
            {
                if (Request.Params["action"] == "edit") //if it's an update (edit)
                {
                    List<Course> courseList = entityContext.Courses.ToList<Course>();
                    course.Title = courseNameTxt.Text; //changing course number on db
                    entityContext.Entry(course).State =
                        System.Data.Entity.EntityState.Modified;
                    entityContext.SaveChanges();
                    courseNameTxt.Text = "";
                    courseNumberTxt.Text = "";
                    courseNumberTxt.Enabled = true;

                    //coming back to home page to display courses from updated database
                    Response.Redirect("AddCourse.aspx");
                }
                else //if creating a course with an existing number (error)
                {
                    spanNumber.InnerText = "Course with this code already exists!";
                    List<Course> courseList = entityContext.Courses.ToList<Course>();

                    //display courses from updated database
                    foreach (Course c1 in courseList)
                    {
                        TableRow row = new TableRow();
                        TableCell cell = new TableCell();
                        cell.Text = c1.Code.ToString();
                        row.Cells.Add(cell);
                        cell = new TableCell();
                        cell.Text = c1.Title.ToString();
                        row.Cells.Add(cell);
                        cell = new TableCell();
                        cell.Text = "<a href='AddCourse.aspx?action=edit&id=" + c1.Code + "'>Edit</a>" + " | " +
                            "<a class='deleteCourse' href='AddCourse.aspx?action=delete&id=" + c1.Code + " '>Delete</a>";
                        row.Cells.Add(cell);
                        tableSort.Rows.Add(row);
                    }
                }               
            }           
        }
    }
}