using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransferFrom : System.Web.UI.Page
{
    List<Customer> allCustomers = Customer.GetAllCustomers();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) //printing list of all users available
        {
            foreach (Customer cust in allCustomers)
            {
                ListItem item = new ListItem(cust.ToString(), cust.Id.ToString()); //display all customers in first page
                dropDownListFrom.Items.Add(item);
            }
        }

        //populating info in case the page is being loaded again:
        if (Session["fromCustID"] != null)
        {
            dropDownListFrom.SelectedValue = (string)Session["fromCustID"]; //bring selected client
        }
        if (Session["transferAmount"] != null)
        {
            amountFrom.Text = (string)Session["transferAmount"]; //bring amount
        }
        if (Session["accountType"] != null)
        {
            if ((string)Session["accountType"] == "Checking Account")
            {
                RadioButtonList1.SelectedIndex = 0; //select checking again               
            }
            if ((string)Session["accountType"] == "Saving Account")
            {
                RadioButtonList1.SelectedIndex = 1;  //select saving again              
            }
            RadioButtonList1.Items[0].Text = (string)Session["custCheckingBalance"]; //bring checking balance
            RadioButtonList1.Items[1].Text = (string)Session["custSavingBalance"]; //bring saving balance
        }   
    }
    
    protected void dropDownListFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropDownListFrom.SelectedValue != "-1")
        {
            int selectedCustomerId = int.Parse(dropDownListFrom.SelectedValue);//creating variable id for selection value on dropdown list
            Customer selectedCustomer = Customer.GetCustomerById(selectedCustomerId);//creating customer according to id
            CheckingAccount customerChecking = selectedCustomer.Checking;//creating checking account for selected customer
            RadioButtonList1.Items[0].Text = customerChecking.ToString(); //showing checking balance for selected users
            Session["custCheckingBalance"] = customerChecking.ToString(); //creating checking balance for future use
            SavingAccount customerSaving = selectedCustomer.Saving;//creating saving account for selected customer
            RadioButtonList1.Items[1].Text = customerSaving.ToString(); //showing savings balance for selected 
            Session["custSavingBalance"] = customerSaving.ToString(); //creating saving balance for future use
        }
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        //validating values:
        if (dropDownListFrom.SelectedValue == "-1") //no name selected
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
                if (amountFrom.Text == "") //no amount typed
                {
                    errorSpanAmount.InnerText = "You must type an amount!";
                }
                else
                {
                    errorSpanAmount.InnerText = "";
                    if (int.Parse(amountFrom.Text) < 0) //negative value typed
                    {
                        errorSpanAmount.InnerText = "You must type a positive value!";
                    }
                    else
                    {
                        errorSpanAmount.InnerText = "";
                        int selectedCustomerId = int.Parse(dropDownListFrom.SelectedValue);//creating variable id for selection value on dropdown list        
                        Session["fromCustID"] = selectedCustomerId.ToString(); //creating sessions for future use of Id in other pages                 
                        Customer selectedCustomer = Customer.GetCustomerById(selectedCustomerId);//creating customer according to id
                        Session["fromCustName"] = selectedCustomer.Name.ToString();  //creating sessions for future use of Name in other pages
                        CheckingAccount customerChecking = selectedCustomer.Checking;//creating checking account for selected customer
                        SavingAccount customerSaving = selectedCustomer.Saving;//creating saving account for selected customer
                        int checking = int.Parse(customerChecking.Balance.ToString()); //creating variable for checking balance
                        int saving = int.Parse(customerSaving.Balance.ToString()); //creating variable for saving balance
                        int amount = int.Parse(amountFrom.Text); //creating variable for amount                        

                        //validating values
                        if (RadioButtonList1.SelectedValue == "0") //checking account
                        {
                            if (amount > checking) //compare checking X amount
                            {
                                errorSpanAmount.InnerText = "Insufficient funds";                                
                            }
                            else
                            {                               
                                if (selectedCustomer.Status == CustomerStatus.REGULAR && amount > 300)
                                {
                                    errorSpanAmount.InnerText = "This transfer can't be bigger than $300.";                                   
                                }
                                else //forwardig to the next page:
                                {
                                    Session["accountType"] = "Checking Account";
                                    Session["fromCustBalance0"] = selectedCustomer.Checking.Balance.ToString();
                                    Session["transferAmount"] = amountFrom.Text; //keeping amount value to be used in the future
                                    Response.Redirect("FundTransferTo.aspx");
                                }
                            }
                        }
                        if (RadioButtonList1.SelectedValue == "1") //saving
                        {
                            if (amount > saving) //compare checking X amount
                            {
                                errorSpanAmount.InnerText = "Insufficient funds!";                                
                            }
                            else //forwardig to the next page:
                            {
                                Session["accountType"] = "Saving Account";
                                Session["fromCustBalance1"] = selectedCustomer.Saving.Balance.ToString();
                                Session["transferAmount"] = amountFrom.Text; //keeping amount value to be used in the future
                                Response.Redirect("FundTransferTo.aspx");
                            }
                        }          
                    }                    
                }
            }
        }
    }
}