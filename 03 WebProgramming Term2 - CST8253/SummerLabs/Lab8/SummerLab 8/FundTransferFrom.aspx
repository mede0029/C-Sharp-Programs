<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransferFrom.aspx.cs" Inherits="FundTransferFrom" %>

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
            <legend><asp:Label ID="Label1" class="LargeDistinct" runat="server" Text="Transfer from:"></asp:Label></legend>
            <br />
            <span id="errorSpanName" runat="server" class="error"></span>
            <br />
            <asp:DropDownList ID="dropDownListFrom" runat="server" OnSelectedIndexChanged="dropDownListFrom_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem Value="-1">Select a transferor...</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="From account:"></asp:Label>
            <br />
            <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Value="0">Checking</asp:ListItem>
                <asp:ListItem Value="1">Saving</asp:ListItem>
            </asp:RadioButtonList>          
            <span id="errorSpanAccount" runat="server" class="error"></span>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Amount: "></asp:Label>
            <asp:TextBox ID="amountFrom" CssClass="input" runat="server"></asp:TextBox>
            <span id="errorSpanAmount" runat="server" class="error"></span>
            <br />
            <br />
            <asp:Button ID="submitBtn" runat="server" Text="Next" OnClick="submitBtn_Click" />
       </fieldset>
    </form>
</body>
</html>
