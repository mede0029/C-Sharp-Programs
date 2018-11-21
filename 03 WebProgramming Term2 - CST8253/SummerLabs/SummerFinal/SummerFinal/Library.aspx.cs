using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library : System.Web.UI.Page
{
    public const int MaxNumOfCheckOut = 3;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Book> availableBooks = Book.AvailableBooks;
            lblDescription.Visible = false;
            lblConfirmation.Visible = false;

            //diplaying list:
            foreach (Book bookItem in availableBooks)
            {                
                ListItem item = new ListItem(bookItem.Title, bookItem.Id);
                drpBookSelection.Items.Add(item);//why only displays title for item? what if I wanted to display ID?
            }      
        }
    }
    protected void drpBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {        
        string selectedBookId = drpBookSelection.SelectedValue; //get index value from selection
        Book selectedBook = Book.GetBookById(selectedBookId); //instanciate book object according to index
        lblDescription.Text = selectedBook.Description; //display description
        lblDescription.Visible = true;
        lblConfirmation.Visible = false;
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        List<Book> checkedOutBooks = new List<Book>(); //creating list of checked out books for counter   

        if (Session["checkedOutSession"] != null) //recovering values if there was a book on checked out before
        {
            checkedOutBooks = (List<Book>)Session["checkedOutSession"];
        }

        if (checkedOutBooks.Count < MaxNumOfCheckOut)
        {
            string selectedBookId = drpBookSelection.SelectedValue; //get index value from selection
            Book selectedBook = Book.GetBookById(selectedBookId); //instanciating book object according to index
            checkedOutBooks.Add(selectedBook); //adding book to checked out books list
            drpBookSelection.Items.Remove(drpBookSelection.SelectedItem); //removing book from displayed list
            Book.MakeBookUnavailable(selectedBookId); //remove book from available list
            lblDescription.Visible = false;
            lblConfirmation.Visible = true;
            lblConfirmation.Text = "You just checked out: '" + selectedBook.Title + "'. <br/>";
            lblConfirmation.Text += "You can check out " + (MaxNumOfCheckOut - checkedOutBooks.Count) + " more book(s).";
            Session["checkedOutSession"] = checkedOutBooks; //the check out button refreshes the page, which resets the checked box list
                                                            //creating a session to continue using the values
        }
        else
        {
            lblDescription.Visible = false;
            lblConfirmation.Visible = true;
            lblConfirmation.Text = "You have checked out the maximum number of books allowed.";
        }
    }
}