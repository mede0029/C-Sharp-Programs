<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/App_Themes/SiteStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Panel ID="pnlGreeting" runat="server" CssClass="displayPanel">
         <h1>Student Record System</h1>
         <p>Welcome to Algonquin College's Student Records System!</p><br />
         <p>Click the top menu to add new courses, or add student records to courses</p>
    </asp:Panel>
    <asp:Panel ID="pnlLogin" runat="server" CssClass="displayPanel">
        <div class="row vertical-margin">
            <div class="col-md-10 col-md-offset-1">
                <h1>Log in</h1>
                <p>Please log in with your user name and password.</p>
            </div>
        </div>
        <br />
        <div class="row vertical-margin  form-group">
            <div class="col-md-3 col-md-offset-1">
                <label for="txtUserName" id="lblUserName">User Name: </label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">         
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" CssClass="error" Display="Static" ErrorMessage="Required!" runat="server"/>
            </div>
        </div>
        <div class="row vertical-margin form-group">
            <div class="col-md-3 col-md-offset-1">
                <label for="txtPassword" id="lblPassword" >Password:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtPassword" TextMode ="Password" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword"  CssClass="error" Display="Static" ErrorMessage="Required!" runat="server"/>
            </div>
        </div>
        <div class="row vertical-margin form-group">
            <div class="col-md-9 col-md-offset-4">
                <asp:Label ID="lblLoginError" CssClass="error" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row vertical-margin">
             <div class="col-md-4 col-md-offset-1">
                <asp:Button ID="btnLogin" runat="server" Text="Log in" cssClass="btn btn-primary" OnClick="btnLogin_Click"/> 
             </div>
        </div>
    </asp:Panel>
</asp:Content>