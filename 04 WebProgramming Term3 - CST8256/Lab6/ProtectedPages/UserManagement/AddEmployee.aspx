<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="AddEmployee.aspx.cs" Inherits="AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add New Employee</h1><br />

    <asp:Label ID="name" runat="server" Text="Name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="nameTxt" runat="server"></asp:TextBox>
    <%-- Required Field Validator --%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="nameTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator><br />
  


    <br />
    <br />
  


    <asp:Label ID="userName" runat="server" Text="User name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="userNameTxt" runat="server"></asp:TextBox>
    <%-- Add Required Field Validator --%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" name="userNameTxtVal" ControlToValidate="userNameTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator>  
    <span id="spanUserName"  runat="server" style="color:red">
    <br /></span><br /><br />
    

    <asp:Label ID="password" runat="server" Text="Password:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="passwordTxt" runat="server"></asp:TextBox>
    <%-- Add Required Field Validator --%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="passwordTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator> 
    
  

    <br />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Roles:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:CheckBoxList ID="checkBox" runat="server" >
        <%--values for checked box are retrieved directly from database, in a foreach loop--%>
    </asp:CheckBoxList>

    <span id="validateCheckList"  runat="server" style="color:red"></span><br /><br /><br />

    <asp:Button ID="submitBtn" runat="server" Text="Save" Width="222px" OnClick="submitBtn_Click"/>
  

    <br />
    <br />
    <br />
    <br />
    <p>The following courses are currently in the system:</p> 

    <asp:Table runat="server" ID="tableSort" CssClass="table" >
    <asp:TableRow>
        <asp:TableHeaderCell>Name</asp:TableHeaderCell>
        <asp:TableHeaderCell>User Name</asp:TableHeaderCell>  
        <asp:TableHeaderCell>Roles</asp:TableHeaderCell>           
    </asp:TableRow>
    </asp:Table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
    <script>
        $(document).ready(function () {
            $(".deleteCourse").on('click', function () {
                if (!confirm("Selected course and its student records will be deleted!")) {
                    return false;
                }
            });
        });
    </script>
</asp:Content>

