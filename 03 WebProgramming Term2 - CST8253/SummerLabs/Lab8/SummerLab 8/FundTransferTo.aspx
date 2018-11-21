<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferTo.aspx.cs" Inherits="FundTransfer" %>

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
            <legend class="LargeDistinct">Transferee</legend>
            <br />
            <asp:DropDownList ID="dropDownListTo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropDownListTo_SelectedIndexChanged">
                <asp:ListItem Value="-1">Select a transferee...</asp:ListItem>
            </asp:DropDownList>
            <br />
            <span id="errorSpanName" runat="server" class="error"></span>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="To account:"></asp:Label>
            <br />
            <br /
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Value="0">Checking</asp:ListItem>
                <asp:ListItem Value="1">Saving</asp:ListItem>
            </asp:RadioButtonList>  
            <span id="errorSpanAccount" runat="server" class="error"></span>
            <br />
            <br />
            <asp:Button ID="backBtn" class="button"   runat="server" Text="Back" OnClick="backBtn_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="nextBtn" class="button" runat="server" Text="Next" OnClick="nextBtn_Click" />
            <br />
            <br />


        </fieldset>




    </form>
</body>
</html>
