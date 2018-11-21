using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //get all books in the catalog - OK
            List<Book> books = BookCatalogDataAccess.GetAllBooks();
            foreach (Book book in books)
            {
                //todo: Populate dropdown list selections - OK
                ListItem item = new ListItem(book.Title, book.Id); //creating a new list with book title
                drpBookSelection.Items.Add(item); //printing the list
            }
        }
        ShoppingCart shoppingcart = null;
        if (Session["shoppingcart"] == null)
        {
            shoppingcart = new ShoppingCart();
            //todo: add cart to the session OK
            Session["shoppingcart"] = shoppingcart;
        }
        else 
        {
            //todo: retrieve cart from the session OK
            shoppingcart = (ShoppingCart)Session["shoppingcart"];
            foreach(BookOrder order in shoppingcart.BookOrders)
            {
                //todo: Remove the book in the order from the dropdown list - OK
                drpBookSelection.Items.Remove(drpBookSelection.Items.FindByValue(order.Book.Id));
            }
        }

        if (shoppingcart.NumOfItems == 0)
            lblNumItems.Text = "empty";
        else if (shoppingcart.NumOfItems == 1)
            lblNumItems.Text = "1 item";
        else
            lblNumItems.Text = shoppingcart.NumOfItems.ToString() + " items";       
    }
    protected void drpBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpBookSelection.SelectedValue != "-1")
        {
            //todo: Display the selected book's description and price OK
            List<Book> books = BookCatalogDataAccess.GetAllBooks(); //creating the list of all books
            string bookId = drpBookSelection.SelectedItem.Value; //creating the string ID for the selected item
            int bookIdInt = int.Parse(drpBookSelection.SelectedItem.Value) -1; //parsing ID into int
            Book selectedBook = books[bookIdInt]; //selecting book from list
            String bookDescription = selectedBook.Description; //creating description string
            lblDescription.Text = bookDescription; //adding the description information 
            String bookPrice = selectedBook.Price.ToString(); //creating price string
            lblPrice.Text = bookPrice; //adding the price information

            //todo: Add selected book to the session OK
            Session["selectedBooksSession"] = selectedBook;
        }
        else
        {
            //todo: Set description and price to blank OK
            lblDescription.Text = "";
            lblPrice.Text = "";
        }
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {

        if (drpBookSelection.SelectedValue != "-1" && Session["shoppingcart"] != null)
        {
            //todo: Retrieve selected book from the session - OK
            Book selectedBook = (Book)Session["selectedBooksSession"];
            String bookTitle = selectedBook.Title; //creating book title string

            //todo: get user entered quqntity - OK
            int bookQuantity = int.Parse(txtQuantity.Text);

            //todo: Create a book order with selected book and quantity - OK
            BookOrder newOrder = new BookOrder(selectedBook, bookQuantity);

            //todo: Retrieve to cart from the session - OK
            ShoppingCart newCart = new ShoppingCart();
            if (Session["shoppingcart"] != null)
            {
                newCart = (ShoppingCart)Session["shoppingcart"];
            }

            //todo: Add book order to the shopping cart - OK        
            newCart.AddBookOrder(newOrder);
            Session["shoppingcart"] = newCart;

            //todo: Remove the selected item from the dropdown list - OK
            drpBookSelection.Items.Remove(drpBookSelection.SelectedItem);

            //todo: Set the description to show title and quantity of the book user added to the shopping cart - OK
            lblDescription.Text = "";
            lblPrice.Text = "";            
            lblDescription.Text = txtQuantity.Text + " copy(s) of " + bookTitle + " was added to the shopping cart.";
            txtQuantity.Text = "";

            //todo: Set the dropdown list's selected value as "-1" - OK   
            drpBookSelection.SelectedIndex = -1;

            //todo: Update the number of items in shopping cart displayed next to the link to ShoppingCartView.aspx - OK    
            if (newCart.NumOfItems == 0)
                lblNumItems.Text = "empty";
            else if (newCart.NumOfItems == 1)
                lblNumItems.Text = "1 item";
            else
                lblNumItems.Text = newCart.NumOfItems.ToString() + " items";
        }
    }
}