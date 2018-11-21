using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewCheckedOutBooks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblNumCheckouts.Text = Book.checkedOut.Count;

        if (Book.AvailableBooks.Count > 0)
        {
            foreach (Book book in Book.AvailableBooks)
            {
                ListItem item = new ListItem(book.Title); //creating a new list with book title
                lstCheckedOutBooks.Items.Add(item);//printing the list
            }
        }
        else
        {
            erroSpan.InnerText = "You have checked out 0 books";
        }
    }
}