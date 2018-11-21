<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferConfirmation.aspx.cs" Inherits="FundTransfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank of Algonquin</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />

</head>
<body style="background-color: lightyellow">
    <h1>Online Fund Transfer Service</h1>
    <form id="form1" runat="server">
    <fieldset>
        <legend class="LargeDistinct">Review and complete: </legend>


        <p><asp:Label ID="Label1" runat="server" Text="Transferer:" Font-Bold="true" Font-Size="Larger"></asp:Label></p>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="nameFromLbl" runat="server" Text="Name: "></asp:Label>
        <br />
        <asp:Label ID="AccountFromLbl" runat="server" Text="Account: "></asp:Label>
        <br />
        <asp:Label ID="amountFromLbl" runat="server" Text="Amount: "></asp:Label>
        <br />
        <br />        
        <p><asp:Label ID="Label2" runat="server" Text="Transferee:" Font-Bold="true" Font-Size="Larger"></asp:Label></p>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="nameToLbl" runat="server" Text="Name: "></asp:Label>
        <br />
        <asp:Label ID="accountToLbl" runat="server" Text="Account: "></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="backBtn" class="button"  runat="server" Text="Back" OnClick="backBtn_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="completeBtn" class="button" runat="server" Text="Complete" OnClick="completeBtn_Click" />
        <br />
    </fieldset>        
    </form>
</body>
</html>
