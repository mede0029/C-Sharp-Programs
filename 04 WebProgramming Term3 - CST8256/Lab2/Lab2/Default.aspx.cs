using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // After submitted once, any subsequent accessing to this page will redirected to user to the second page
            if (Session["newCourse"] != null)
            {
                Response.Redirect("StudentRecords.aspx");
            }
        }
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        string courseNumber = courseNumberTxt.Text; //getting number variable        
        string courseName = courseNameTxt.Text; //getting name variable     
        Course newCourse = new Course(courseNumber, courseName); //creating course
        Session["courseNumberSession"] = courseNumberTxt.Text; //storing number to session
        Session["courseNameSession"] = courseNameTxt.Text; //storing name to session TEST
        Session["newCourse"] = newCourse.ToString(); //storing new course to session
        Response.Redirect("StudentRecords.aspx"); //going to next page
    }
}