<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="StudentRecords.aspx.cs" Inherits="StudentRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <h1>Course Information</h1>
    <form id="form1" runat="server" visible="true">
        <div>

             <asp:Label ID="courseNumber" runat="server" Text="Student ID:"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="studentIdTxt" runat="server"></asp:TextBox>
             <%-- todo: Add Required Field Validator OKOK --%>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="studentIdTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator> 
             <br />
             <br />
             <asp:Label ID="Label1" runat="server" Text="Student name:"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="studentNameTxt" runat="server"></asp:TextBox>
             <%-- todo: Add Required Field Validator OKOK --%>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="studentNameTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator>            
            <asp:RegularExpressionValidator ID="RegularExpValidator" ValidationExpression="[a-zA-Z]+\s+[a-zA-Z]+" 
                ControlToValidate="studentNameTxt" CssClass="error" Display="Dynamic" ErrorMessage="Must be in first_name last_name!" 
                runat="server"/>
             <br />
             <br />
             <asp:Label ID="Label2" runat="server" Text="Grade (0-100):"></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="studentGradeTxt" runat="server"></asp:TextBox>
             <%-- todo: Add Required Field Validator OKOK --%>
             <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="studentGradeTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator> 
              <%-- todo: Add Range Validator --%><br />
              <asp:RangeValidator ID="RequiredRangeValidator" runat="server" ControlToValidate="studentGradeTxt"
                Type="Integer" ErrorMessage="Grade must be between 0 and 100!" MaximumValue="100" MinimumValue="0" 
                Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
             <br />
             <br />
             <asp:Button ID="submitBtn" runat="server" Text="Add to course record" Width="222px" OnClick="submitBtn_Click" />
             <br />
             <br />    

 
             <asp:Label ID="Label3" runat="server" Text="Following student records have been added: " ></asp:Label>
             <br />
             <br />
             <asp:Label ID="orderBy" runat="server" Text="Order by: " ></asp:Label>
             <asp:RadioButtonList ID="sortType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="sortType_SelectedIndexChanged" 
                 AutoPostBack="true">
                 <asp:ListItem Value="0">ID</asp:ListItem>
                 <asp:ListItem Value="1">Name</asp:ListItem>
                 <asp:ListItem Value="2">Grade</asp:ListItem>
             </asp:RadioButtonList>

             <br />

            <asp:Table runat="server" ID="tableSort" CssClass="table" >
                <asp:TableRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>    
                    <asp:TableHeaderCell>Grade</asp:TableHeaderCell> 
                </asp:TableRow>
            </asp:Table>


        </div>
        </form>
   
</body>
</html>
