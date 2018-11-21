using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRecordDal;

public partial class _Default : BasePage
{
    protected override void Page_Load(object sender, EventArgs e)
    {
        base.Page_Load(sender, e);
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome"); //instanciating Home button
        btnHome.Enabled = false; //disabling link for Home Menu
    }
}