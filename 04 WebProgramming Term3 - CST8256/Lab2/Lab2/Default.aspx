<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Courses</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <h1>Course Information</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="courseNumber" runat="server" Text="Course number:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="courseNumberTxt" runat="server"></asp:TextBox>           
            <%-- todo: Add Required Field Validator OKOK --%>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="courseNumberTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator>    
            
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Course name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="courseNameTxt" runat="server"></asp:TextBox>
             <%-- todo: Add Required Field Validator OKOK --%>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="courseNameTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator>    

            <br /> <br />
            <asp:Button ID="submitBtn" runat="server" Text="Submit Course Information" Width="222px" OnClick="submitBtn_Click" />


            <br /><br />
            <asp:Label ID="Label3" runat="server" Text="The selected course had the following student record(s): " ></asp:Label> 



        </div>        
    </form>
</body>
</html>
