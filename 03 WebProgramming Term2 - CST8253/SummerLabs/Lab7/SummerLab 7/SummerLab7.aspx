<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SummerLab7.aspx.cs" Inherits="SummerLab7" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Algonquin College Course Registration</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>

<body>   
    <h1><asp:Label ID="Label1" runat="server" Text="Algonquin College Course Registration"></asp:Label></h1>
    <form id="form1" runat="server">

        <div class="stname">
            <br />
            <asp:Label  ID="studentNameLbl" runat="server" Text="Student name: "></asp:Label>
            <asp:TextBox ID="studentNameTxt" runat="server" OnTextChanged="studentNameTxt_TextChanged" CssClass="input"></asp:TextBox>
        </div>
        <div class="stcourse">
            <asp:RadioButtonList ID="radioButtonLst" runat="server" RepeatDirection="Horizontal" Height="66px">
                <asp:ListItem>Full-Time</asp:ListItem>
                <asp:ListItem>Part-Time</asp:ListItem>
                <asp:ListItem>Co-op</asp:ListItem>
            </asp:RadioButtonList>       
        </div>        
        <div>
            <h3>&nbsp;</h3>
            <h3>&nbsp;</h3>
            <h3><asp:Label ID="Label2" runat="server" Text="Following courses are currently available for registration: "></asp:Label>
            </h3>
            <br />
        </div>
        <div>
            <asp:CheckBoxList ID="checkBoxLst" runat="server"></asp:CheckBoxList>
        </div>
        <div>
            <br />
            <asp:Button ID="button" class="button" runat="server" Text="Submit" OnClick="button_Click" />
            <br /><br /><span id="erroSpan" runat="server" class="error"></span>
        </div>
    </form>

    <form id="form2" runat="server" visible="false">
        <p>Thank you <span id="spanName" runat="server" class="emphsis"></span> for using our online registration system. </p>
        <p>You have been registered as a <span id="spanType" runat="server" class="distinct"></span> student for the following courses:</p>

        <asp:Table ID="resultTable" runat="server" CssClass="table">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell>Course Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Course Title</asp:TableHeaderCell>
                <asp:TableHeaderCell>Weekly Hours</asp:TableHeaderCell>
                <asp:TableHeaderCell>Fee Payable</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </form>

</body>
</html>


