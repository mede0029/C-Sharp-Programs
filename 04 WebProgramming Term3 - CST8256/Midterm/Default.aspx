<%@ page title="" language="C#" masterpagefile="~/ACMasterPage.master" autoeventwireup="true" codefile="Default.aspx.cs" inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/App_Themes/SiteStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row vertical-margin">
        <div class="col-md-10 col-md-offset-1">
            <h1>Online Registration System</h1>
        </div>
    </div>
    <asp:Panel ID="pnlWelcome" runat="server" CssClass="displayPanel">
        <div class="row vertical-margin">
            <div class="col-md-10 col-md-offset-1">
                <h3>Welcome <asp:Label runat="server" ID="lblName"></asp:Label>!</h3>
                <p>Click the link to view <a href="CurrentRegistrations.aspx"><span style="font-weight:bold">your current registrations</span></a></p>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlLogin" runat="server" CssClass="displayPanel">
        <div class="row vertical-margin">
            <div class="col-md-10 col-md-offset-1">
                <p>To log in, enter your Student Number and password:</p>
            </div>
        </div>
        <br />
        <div class="row vertical-margin  form-group">
            <div class="col-md-3 col-md-offset-1">
                <label for="txtStudentNum" id="lblStudentNum">Student Number: </label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtStudentNum" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">         
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtStudentNum" CssClass="error" Display="Static" ErrorMessage="Required!" runat="server"/>
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

