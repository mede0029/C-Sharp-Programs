<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add New Courses</h1><br />

    <asp:Label ID="courseNumber" runat="server" Text="Course number:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="courseNumberTxt" runat="server"></asp:TextBox>
    <%-- Required Field Validator --%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="courseNumberTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator>  <br /><br />


    <asp:Label ID="Label1" runat="server" Text="Course name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="courseNameTxt" runat="server"></asp:TextBox>
    <%-- Add Required Field Validator --%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="courseNameTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator>     

    <br /><br /><br />
    <asp:Button ID="submitBtn" runat="server" Text="Submit Course Information" Width="222px" OnClick="submitBtn_Click" />

    <br /><br />
    <p>The following courses are currently in the system:</p> 

    <asp:Table runat="server" ID="tableSort" CssClass="table" >
    <asp:TableRow>
        <asp:TableHeaderCell><a href="AddCourse.aspx?sort=code">Course Code</a></asp:TableHeaderCell>
        <asp:TableHeaderCell><a href="AddCourse.aspx?sort=title">Couse Title</asp:TableHeaderCell>    
        
    </asp:TableRow>
    </asp:Table>



</asp:Content>

