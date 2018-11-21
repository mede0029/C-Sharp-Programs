<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferResult.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">

        <asp:Label ID="Label1" runat="server" Text="Thank you for using online transfer service!" Font-Size="Larger"></asp:Label>
        <br />
        <br />
        <asp:Label ID="resultAmount" runat="server" Text="Amount XXX has been trasnferred." Font-Size="Larger"></asp:Label>
        <br />
        <p><asp:Label ID="Label3" runat="server" Text="From:" Font-Bold="true" Font-Size="Larger"></asp:Label></p>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="nameFromLbl" runat="server" Text="Name: "></asp:Label>
        <br />
        <asp:Label ID="AccountFromLbl" runat="server" Text="Account: "></asp:Label>
        <br />
        <br />
        <br />        
        <p><asp:Label ID="Label2" runat="server" Text="To:" Font-Bold="true" Font-Size="Larger"></asp:Label></p>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="nameToLbl" runat="server" Text="Name: "></asp:Label>
        <br />
        <asp:Label ID="accountToLbl" runat="server" Text="Account: "></asp:Label>


        <br />
        <br />
        <br />
        <asp:Button ID="Button1" class="button" runat="server" Text="Start a new transfer" Width="248px" OnClick="Button1_Click" />


    </form>
</body>
</html>
