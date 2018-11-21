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
        if (!IsPostBack)
        {
            if (Session["checkedOutSession"] != null)
            {
                foreach (Book bookItem in (List<Book>)Session["checkedOutSession"])
                {
                    ListItem item = new ListItem(bookItem.Title, bookItem.Id);
                    lstCheckedOutBooks.Items.Add(item);
                }
            }
            else
            {
                lblNumCheckouts.Text = " 0 ";
            }

        }



    }

}