using System;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PageBase
/// </summary>
public class BasePage : System.Web.UI.Page
{
    protected virtual void Page_Load(object sender, EventArgs e)
    {
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
        btnHome.Click += (s, a) => Response.Redirect("Default.aspx");
        BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");
        if (!IsPostBack)
        {           
            topMenu.Items.Add(new ListItem("Add Courses"));
            topMenu.Items.Add(new ListItem("Add Student Records"));
        }
        topMenu.Click += topMenu_Click;
    }

    protected void topMenu_Click(object sender, BulletedListEventArgs e)
    {
        if (e.Index == 0)
        {
            Response.Redirect("AddCourse.aspx");
        }
        else if (e.Index == 1)
        {
            Response.Redirect("AddStudent.aspx");
        }
    }
}