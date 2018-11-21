using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlgonquinCollege.Registration.Entities;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome"); //instanciating Home button
        btnHome.Enabled = false; //disabling link for Home Menu

        BulletedList topMenu = (BulletedList)Master.FindControl("topMenu"); //instanciationg Top Menu
        if (!IsPostBack) //adding items to Top Menu
        {
            topMenu.Items.Add(new ListItem("Add Courses"));
            topMenu.Items.Add(new ListItem("Add Student Records"));
        }
        topMenu.Click += topMenu_Click; 
    }

    protected void topMenu_Click (object sender, BulletedListEventArgs e) //adding actions to the Top Menu Items
    {
        if (e.Index == 0)
        {
            Response.Redirect("AddCourse.aspx");
        }
        if (e.Index == 1)
        {
            Response.Redirect("AddStudent.aspx");
        }
    }
}




