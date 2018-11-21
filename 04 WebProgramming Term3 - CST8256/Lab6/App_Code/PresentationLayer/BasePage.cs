using System;
using System.Web.Security;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected virtual void Page_Load(object sender, EventArgs e)
    {
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
        btnHome.Click += (s, a) => Response.Redirect("http://localhost:61731/Default.aspx");

        LinkButton btnLogout = (LinkButton)Master.FindControl("btnLogout");
        btnLogout.Visible = false;

        BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");
        topMenu.Items.Clear();

        if (Request.IsAuthenticated)
        {
            topMenu.Items.Add(new ListItem("Add Courses"));
            topMenu.Items.Add(new ListItem("Add Student Records"));
            topMenu.Items.Add(new ListItem("Add Employee"));
            topMenu.Click += topMenu_Click;

            btnLogout.Visible = true;
            btnLogout.Click += btnLogout_Click;


            topMenu.Items[0].Enabled = false;
            topMenu.Items[1].Enabled = false;
            topMenu.Items[2].Enabled = false;

            if (User.IsInRole("Department Chair"))
            {
                topMenu.Items[2].Enabled = true;
            }
            if (User.IsInRole("Coordinator"))
            {
                topMenu.Items[0].Enabled = true;
            }
            if (User.IsInRole("Instructor"))
            {
                topMenu.Items[1].Enabled = true;
            }
        }
    }

    protected void topMenu_Click(object sender, BulletedListEventArgs e)
    {
        if (e.Index == 0)
        {
            Response.Redirect("/ProtectedPages/CourseManagement/AddCourse.aspx");
        }
        else if (e.Index == 1)
        {
            Response.Redirect("/ProtectedPages/RecordManagement/AddStudent.aspx");
        }
        else if (e.Index == 2)
        {
            Response.Redirect("/ProtectedPages/UserManagement/AddEmployee.aspx");
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        FormsAuthentication.SignOut();

        Response.Redirect("/Default.aspx");
    }

}