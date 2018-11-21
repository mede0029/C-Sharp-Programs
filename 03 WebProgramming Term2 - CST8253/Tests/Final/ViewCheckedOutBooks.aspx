<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewCheckedOutBooks.aspx.cs" Inherits="ViewCheckedOutBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Algonquin College Library</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body> 
    <div class="center">
        <h1 style="text-align:center">Algonquin College Library</h1>
        <form id="form1" runat="server">
            <div>
            <p>You have checked out <asp:Label runat="server" ID="lblNumCheckouts"></asp:Label> book(s): </p>
            <asp:BulletedList runat="server" ID="lstCheckedOutBooks">
            </asp:BulletedList>

            <span id="erroSpan" runat="server" class="error"></span>
            <div>
                <br />
                <a href="Library.aspx">Back to Library</a>
            </div>
            </div>
        </form>
    </div>
</body>
</html>
