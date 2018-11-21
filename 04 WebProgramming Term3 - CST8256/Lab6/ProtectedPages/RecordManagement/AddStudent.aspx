<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" Debug="true" CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add Student Records</h1>
    <br />
    <br />
    <asp:Label ID="courseLbl" runat="server" Text="Course: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
        <asp:ListItem Value="0">Please select a course</asp:ListItem>
    </asp:DropDownList>
    <%-- Required Field Validator --%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="DropDownList1" 
                ErrorMessage="This information is required!" InitialValue="0" ForeColor="Red"></asp:RequiredFieldValidator>  <br /><br />   

    <br /> <br />
    <asp:Label ID="studentNumberLbl" runat="server" Text="Student Number:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="studentNumberTxt" runat="server"></asp:TextBox>
    <%-- Required Field Validator --%>
     &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="studentNumberTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator><br />
    <span id="spanNumber"  runat="server" style="color:red"></span><br />

    <br /><br />
    <asp:Label ID="studentNameLbl" runat="server" Text="Student Name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="studentNameTxt" runat="server"></asp:TextBox>
    <%-- Required Field Validator --%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="studentNameTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator><br />            
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;            
    <asp:RegularExpressionValidator ID="RegularExpValidator" ValidationExpression="[a-zA-Z]+\s+[a-zA-Z]+" 
                ControlToValidate="studentNameTxt" CssClass="error" Display="Dynamic" ErrorMessage="Must be in first_name last_name!" 
                runat="server"/>

    <br /><br />
    <asp:Label ID="gradeLbl" runat="server" Text="Grade:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="gradeTxt" runat="server"></asp:TextBox>
    <%-- Required Field Validator --%>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="gradeTxt" 
                ErrorMessage="This information is required!" InitialValue="" ForeColor="Red"></asp:RequiredFieldValidator> 
    <%-- Add Range Validator --%><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RangeValidator ID="RequiredRangeValidator" runat="server" ControlToValidate="gradeTxt"
                Type="Integer" ErrorMessage="Grade must be between 0 and 100!" MaximumValue="100" MinimumValue="0" 
                Display="Dynamic" ForeColor="Red"></asp:RangeValidator>
    
    <br /> <br /><br />
    <asp:Button ID="addBtn" runat="server" Text="Save" Width="222px" OnClick="addBtn_Click"   />

    <br /><br /><br /><br />
    <asp:Table runat="server" ID="tableSort" CssClass="table" >
    <asp:TableRow>
        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
        <asp:TableHeaderCell>Name</asp:TableHeaderCell>    
        <asp:TableHeaderCell>Grade</asp:TableHeaderCell> 
        <asp:TableHeaderCell>Action</asp:TableHeaderCell> 
    </asp:TableRow>
            </asp:Table>         
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
    <script>
        $(document).ready(function () {
            $(".deleteAcademicRecord").on('click', function () {
                if (!confirm("Selected academic course will be deleted!")) {
                    return false;
                }
            });
        });
     </script>
</asp:Content>

