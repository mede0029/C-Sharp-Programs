using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShoppingCartView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["shoppingcart"] == null)
        {
            //todo: Redirect the user to Bookstore.aspx page - OK
            Response.Redirect("BookStore.aspx");
        }
        else
        {
            //todo: Retrieve shopping cart from the session - OK
            ShoppingCart shoppingcart = (ShoppingCart)Session["shoppingcart"];

            //todo: Call DisplayShoppingCart method to display shopping cart - OK
            DisplayShoppingCart(shoppingcart);
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        //todo: Redirect the user to Bookstore.aspx page - OK
        Response.Redirect("BookStore.aspx");
    }

    protected void btnEmptyShoppingCart_Click(object sender, EventArgs e)
    {
        //todo: Retrieve shopping cart from session - OK
        ShoppingCart shoppingcart = (ShoppingCart)Session["shoppingcart"];

        //todo: Clear shopping cart - OK
        ShoppingCart cart = new ShoppingCart();
        Session["shoppingcart"] = null;
        //could have been done such as: shopingcart.BookOrders.Clear();

        //todo: Call DisplayShoppingCart method to display shopping cart - OK
        for (int i = tblShoppingCart.Rows.Count - 1; i > 0; i--)
        {
            tblShoppingCart.Rows.RemoveAt(i);
        }
        DisplayShoppingCart(cart);
    }

    private void DisplayShoppingCart(ShoppingCart cart)
    {
        if (cart.IsEmpty)       
        {

            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "Your Shopping Cart is Empty";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblShoppingCart.Rows.Add(lastRow);
        }
        else
        {
            foreach (BookOrder order in cart.BookOrders)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = order.Book.Title;
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = order.NumOfCopies.ToString();
                row.Cells.Add(cell);
                cell = new TableCell();
                cell.Text = "$" + order.NumOfCopies * order.Book.Price;
                row.Cells.Add(cell);
                tblShoppingCart.Rows.Add(row);
            }
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "Total";
            lastRowCell.ColumnSpan = 2;
            lastRowCell.HorizontalAlign = HorizontalAlign.Right;
            lastRow.Cells.Add(lastRowCell);
            lastRowCell = new TableCell();
            lastRowCell.Text = "$" + cart.TotalAmountPayable.ToString();
            lastRow.Cells.Add(lastRowCell);
            tblShoppingCart.Rows.Add(lastRow);
        }
    }
}