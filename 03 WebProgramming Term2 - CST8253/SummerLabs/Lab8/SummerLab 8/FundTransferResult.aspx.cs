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

        resultAmount.Text = "Amount $" + (string)Session["transferAmount"] + " has been transferred.";
        
        //retrieving data from trasferor:
        nameFromLbl.Text = "Name: " + (string)Session["fromCustID"] + " - " + (string)Session["fromCustName"];
        if ((string)Session["accountType"] == "Checking Account")
        {
            AccountFromLbl.Text = "Account: Checking Account - $" + (int)Session["withdrawResult"];
        }
        if ((string)Session["accountType"] == "Saving Account")
        {
            AccountFromLbl.Text = "Account: Saving Account - $" + (int)Session["withdrawResult"];
        }

        //retrieving data from transferee:
        nameToLbl.Text = "Name: " + (string)Session["toCustID"] + " - " + (string)Session["toCustName"];
        if ((string)Session["accountTypeTo"] == "Checking Account")
        {
            accountToLbl.Text = "Account: Checking Account - $" + (string)Session["depositResult"];
        }
        if ((string)Session["accountTypeTo"] == "Saving Account")
        {
            accountToLbl.Text = "Account: Saving Account - $" + (string)Session["depositResult"];
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["accountType"] = null;
        Session["accountTypeTo"] = "";
        Session["custCheckingBalance "] = null;
        Session["custCheckingBalanceTo"] = null;
        Session["custSavingBalance"] = null;
        Session["custSavingBalanceTo"] = null;
        Session["depositResult"] = null;
        Session["fromCustBalance0"] = null;
        Session["fromCustBalance1"] = null;
        Session["fromCustID"] = null;
        Session["fromCustName"] = null;
        Session["FundTransferTo"] = null;
        Session["toCustId"] = null;
        Session["toCustName"] = null;
        Session["transferAmount"] = null;
        Session["withdrawnResult"] = null;
        Response.Redirect("FundTransferFrom.aspx");
    }
}