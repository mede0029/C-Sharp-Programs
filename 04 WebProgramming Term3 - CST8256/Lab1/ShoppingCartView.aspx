<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShoppingCartView.aspx.cs" Inherits="ShoppingCartView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Store</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
     <h1>Online Book Store</h1>
    <form id="form1" runat="server">
        <div>
            <p>Please review your shopping cart below.</p>
            <asp:Table runat="server" ID="tblShoppingCart" CssClass="table">
                <asp:TableRow>
                    <asp:TableHeaderCell>Title</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Quantity</asp:TableHeaderCell>    
                    <asp:TableHeaderCell>Subtotal</asp:TableHeaderCell> 
                </asp:TableRow>
            </asp:Table>
        </div>
        <div>
            <asp:Button runat="server"  ID="btnBack" Text="Back to Store" cssclass="button" OnClick="btnBack_Click"/> &nbsp; &nbsp;
            <asp:Button runat="server"  ID="btnEmptyShoppingCart" Text="Empty Cart" cssclass="button" OnClick="btnEmptyShoppingCart_Click"/>
        </div>
    </form>
</body>
</html>
