using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    List<Customer> allCustomers = Customer.GetAllCustomers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (Customer cust in allCustomers)
            {                
                if (cust.Id.ToString().Trim() != (string)Session["fromCustID"]) //disregard the customere selected on first page
                {
                    ListItem item = new ListItem(cust.ToString(), cust.Id.ToString()); //display all customers in second page
                    dropDownListTo.Items.Add(item);
                }                
            }
        }

        //populating info in case the page is being loaded again:
        if (Session["toCustId"] != null)
        {
            dropDownListTo.SelectedValue = (string)Session["toCustId"]; //bring selected client
        }
        if (Session["accountTypeTo"] != null)
        {
            if ((string)Session["accountTypeTo"] == "Checking Account")
            {
                RadioButtonList1.SelectedIndex = 0; //select checking again               
            }
            if ((string)Session["accountTypeTo"] == "Saving Account")
            {
                RadioButtonList1.SelectedIndex = 1;  //select saving again              
            }
        }
    }

    protected void dropDownListTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropDownListTo.SelectedValue != "-1")
        {
            int selectedCustomerId = int.Parse(dropDownListTo.SelectedValue); //creating variable id for selection value on dropdown list
            Customer selectedCustomer = Customer.GetCustomerById(selectedCustomerId); //creating customer according to id
            CheckingAccount customerChecking = selectedCustomer.Checking; //creating checking account for selected customer
            RadioButtonList1.Items[0].Text = customerChecking.ToString(); //showing checking balance for selected customer            
            Session["toCustId"] = selectedCustomerId.ToString(); //keeping customer ID for future use
            Session["toCustName"] = selectedCustomer.Name.ToString(); //keeping customer name for future use        
            SavingAccount customerSaving = selectedCustomer.Saving;//creating saving account for selected customer
            RadioButtonList1.Items[1].Text = customerSaving.ToString(); //showing savings balance for selected users                
        }
    }

    protected void nextBtn_Click(object sender, EventArgs e)
    {
        if (dropDownListTo.SelectedValue == "-1") //no name selected
        {
            errorSpanName.InnerText = "You must choose a name!";
        }
        else
        {
            errorSpanName.InnerText = "";
            if (RadioButtonList1.SelectedItem == null) //no account selected
            {
                errorSpanAccount.InnerText = "You must choose an account!";
            }
            else
            {
                errorSpanAccount.InnerText = "";
                int selectedCustomerId = int.Parse(dropDownListTo.SelectedValue);//creating variable id for selection value on dropdown list
                Session["toCustId"] = selectedCustomerId.ToString();
                Customer selectedCustomer = Customer.GetCustomerById(selectedCustomerId);//creating customer according to id
                Session["toCustName"] = selectedCustomer.Name.ToString(); // creating session for to cust name to be used in the future
                CheckingAccount customerChecking = selectedCustomer.Checking;//creating checking account for selected customer
                RadioButtonList1.Items[0].Text = customerChecking.ToString(); //showing checking balance for selected customer                                                                             
                SavingAccount customerSaving = selectedCustomer.Saving;//creating saving account for selected customer
                RadioButtonList1.Items[1].Text = customerSaving.ToString(); //showing savings balance for selected users
                                                                            
                if (RadioButtonList1.SelectedValue == "0") //checking account
                {
                    Session["accountTypeTo"] = "Checking Account";
                    Session["custCheckingBalanceTo"] = selectedCustomer.Checking.Balance.ToString(); //keeping checking balance for future use
                }
                if (RadioButtonList1.SelectedValue == "1") //saving account
                {
                    Session["accountTypeTo"] = "Saving Account";
                    Session["custSavingBalanceTo"] = selectedCustomer.Saving.Balance.ToString(); //keeping saving balance for future use      
                }
                Response.Redirect("FundTransferConfirmation.aspx");
            }
        }
    }

    protected void backBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundTransferFrom.aspx");
    }
}