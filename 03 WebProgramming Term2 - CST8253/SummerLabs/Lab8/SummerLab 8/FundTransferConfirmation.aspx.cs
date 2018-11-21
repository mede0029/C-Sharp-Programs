using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //retrieving data from trasferor:
        nameFromLbl.Text = "Name: " + (string)Session["fromCustName"];
        if ((string)Session["accountType"] == "Checking Account")
        {     
            AccountFromLbl.Text = "Account: Checking Account - $" + (string)Session["fromCustBalance0"];
        }
        if ((string)Session["accountType"] == "Saving Account")
        {
            AccountFromLbl.Text = "Account: Saving Account - $" + (string)Session["fromCustBalance1"];
        }
        amountFromLbl.Text = "Amount: $" + (string)Session["transferAmount"];

        //retrieving data from transferee:
        nameToLbl.Text = "Name: " + (string)Session["toCustName"];
        if ((string)Session["accountTypeTo"] == "Checking Account")
        {
            accountToLbl.Text = "Account: Checking Account - $" + (string)Session["custCheckingBalanceTo"];
        }
        if ((string)Session["accountTypeTo"] == "Saving Account")
        {
            accountToLbl.Text = "Account: " + (string)Session["custSavingBalanceTo"];
        }
    }

    protected void backBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundTransferTo.aspx");
    }

    protected void completeBtn_Click(object sender, EventArgs e)
    {
        //withdraw
        if((string)Session["accountType"] == "Checking Account")
        {
            string a = (string)Session["fromCustBalance0"];
            int ab = int.Parse(a);
            string b = (string)Session["transferAmount"];
            int ba = int.Parse(b);
            int c = ab - ba;
            Session["withdrawResult"] = c;     
        }
        if ((string)Session["accountType"] == "Saving Account")
        {
            string a = (string)Session["fromCustBalance1"];
            int ab = int.Parse(a);
            string b = (string)Session["transferAmount"];
            int ba = int.Parse(b);
            int c = ab - ba;
            Session["withdrawResult"] = c;
        }

        //deposit
        if ((string)Session["accountTypeTo"] == "Checking Account")
        {
            string checkSt = (string)Session["custCheckingBalanceTo"];
            int checkInt = int.Parse(checkSt);
            string amtSt = (string)Session["transferAmount"];
            int amInt = int.Parse(amtSt);
            int r = checkInt + amInt;
            string rSt = r.ToString();
            Session["depositResult"] = rSt;
        }
        if ((string)Session["accountTypeTo"] == "Saving Account")
        {
            string checkSt = (string)Session["custSavingBalanceTo"];
            int checkInt = int.Parse(checkSt);
            string amtSt = (string)Session["transferAmount"];
            int amInt = int.Parse(amtSt);
            int r = checkInt + amInt;
            string rSt = r.ToString();
            Session["depositResult"] = rSt;
        }
        Response.Redirect("FundTransferResult.aspx");
    }
}