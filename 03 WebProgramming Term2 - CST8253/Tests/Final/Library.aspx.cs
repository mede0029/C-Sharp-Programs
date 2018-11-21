using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Library : System.Web.UI.Page
{
    public const int MaxNumOfCheckOut = 3;
    List<Book> checkedOut = new List<Book>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            List<Book> availableBooks = Book.AvailableBooks;
            lblDescription.Visible = false;
            lblConfirmation.Visible = false;

            //Add your code here       
            foreach (Book book in availableBooks)
            {
                if (book.ToString().Trim() != HttpContext.Current.Session["availableBooks"].ToString()) //removing books already selected
                {
                    ListItem item = new ListItem(book.Title, book.Id); //creating a new list with book title
                    drpBookSelection.Items.Add(item); //printing the list
                }                
            }
        }   
    }
    protected void drpBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        String selectedBookId = drpBookSelection.SelectedValue; //creating variable for id
        Book selectedBook = Book.GetBookById(selectedBookId); // selecting book according to ID
        //String bookDescription = selectedBook.Description; //creating description        
        //lblDescription.Text = bookDescription.ToString(); //adding the description information 
        lblDescription.Text = selectedBook.Description; //adding the description information 
    }

    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        List<Book> checkedOut = new List<Book>(); //creating a list to add checked out books       
        String selectedBookId = drpBookSelection.SelectedValue; //creating variable for id
        Book selectedBook = Book.GetBookById(selectedBookId); // selecting book according to ID
        if (Book.AvailableBooks.Count < 4) //if maximum number of books to be selected is not reached yet
        {
            Book.MakeBookUnavailable(selectedBookId); //removing book from available list?
            Book.AvailableBooks.Remove(selectedBook); //removing book from available list?
            lblConfirmation.Text = "You just checked out: " + selectedBook.Title; //display confirmation message
            lblConfirmation.Text += "You can check out " + (MaxNumOfCheckOut - checkedOut.Count); //display remaining books available
            checkedOut.Add(selectedBook); //adding selected book to checked out books list
            HttpContext.Current.Session["checkedOut"] = checkedOut;//creating a session for checked out books
            drpBookSelection.SelectedIndex = 0; //displays dropdown initial test again
        }
        else
        {
            lblConfirmation.Text = "You have checked out the maximum number of books allowed";
        }
    }
}