<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Library.aspx.cs" Inherits="Library" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Algonquin College Library</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <div class="center">
        <h1 style="text-align:center">Algonquin College Library</h1>
        <p style="width:600px">You can selet a book from the dropdown list to see the book's description. Click the Checkout button to check out the selected book. You can checkout as many books as you want</p>
        <p>Click <a href="ViewCheckedOutBooks.aspx">here</a> to view the books you have checked out. </p>
        <form id="form1" runat="server">
            <asp:DropDownList ID="drpBookSelection" runat="server" CssClass="dropdown" 
                 OnSelectedIndexChanged="drpBookSelection_SelectedIndexChanged" AutoPostBack="true" >
                <asp:ListItem Value="-1">Select a Book ... </asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;<asp:Button runat="server" ID="btnCheckout" Text="Check Out" cssClass="button" OnClick="btnCheckout_Click"/> <br />
            <asp:RequiredFieldValidator runat="server" ID="rqdBookSelection" ControlToValidate="drpBookSelection" ErrorMessage="Must Select One" InitialValue="-1" ForeColor="Red"></asp:RequiredFieldValidator>
            <p style="width:600px">
                <asp:Label runat="server" ID="lblDescription"></asp:Label>
            </p>
            <p style="width:600px">
                <asp:Label runat="server" ID="lblConfirmation"></asp:Label>
            </p>   
        </form>
    </div>
</body>
</html>

