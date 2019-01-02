using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using RegistrationEF;
public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        pnlLogin.Visible = false;
        pnlWelcome.Visible = false;

        //show different penal based on the user's authentication status
        if (!IsPostBack)
        {
            pnlLogin.Visible = true;
        }
        else
        {
            if (Session["validSt"] != null)
            {
                if ((int)Session["validSt"] == 0)
                {
                    pnlLogin.Visible = true;
                    lblLoginError.Text = "Incorrect student number and/or password";
                }
            }
        }

        //display custom message if user was already validated
        if (Session["studentName"] != null)
        {
            pnlWelcome.Visible = true;
            lblName.Text = (string)Session["studentName"];
            pnlLogin.Visible = false;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string studentNum = txtStudentNum.Text;
        string password = txtPassword.Text;

        using (RegistrationDB entityContext = new RegistrationDB())
        {
            //Authenicate the user's credential against data stored 
            var validSt = (from st in entityContext.Students
                           where (st.StudentNum == studentNum && st.Password == password)
                           select st).FirstOrDefault<Student>();

            //if student not found, return to first page with error message
            if (validSt == null)
            {
                Session["validSt"] = 0;
            }
            else //if student is found, save sessions and direct to second page:
            {
                Session["studentName"] = validSt.Name;
                Session["studentNumber"] = validSt.StudentNum;
                Response.Redirect("CurrentRegistrations.aspx");
            }
        }
    }
}