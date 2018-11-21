using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using StudentRecordDal;


public partial class Default : BasePage
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
        btnHome.Enabled = false;

        if (Session["aut"] != null) //if there is an authentication session
        {
            if ((int)Session["aut"] == 1) //if authenticated, hide login and show greeting
            {
                pnlLogin.Visible = false;
                pnlGreeting.Visible = true;
            }
            else //if not authenticated, show login and hide greeting
            {
                pnlLogin.Visible = true;
                pnlGreeting.Visible = false;
            }
        }
        else //if there's no authentication session - login for the first time
        {
            pnlLogin.Visible = true;
            pnlGreeting.Visible = false;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string useName = txtUserName.Text.ToLower().Trim();
        string psd = txtPassword.Text.Trim();
        using (StudentRecordEntities entityContext = new StudentRecordEntities())
        {
            //check if user is in database:
            Employee em = (from emp in entityContext.Employees
                            where emp.UserName == useName && emp.Password == psd
                            select emp).FirstOrDefault<Employee>();
            if (em != null) //if system finds something - user is authenticated
            {
                FormsAuthentication.RedirectFromLoginPage(em.Id.ToString(), false); //authenticating user
                Session["aut"] = 1; //creating session to indicate authentication
            }
            else //user not in database
            {
                lblLoginError.Text = "The entered username and/or password are incorrect!"; 
            }
        }
    }
}