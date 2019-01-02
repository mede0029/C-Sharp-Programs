<%@ page title="" language="C#" masterpagefile="~/ACMasterPage.Master" autoeventwireup="true" codefile="CurrentRegistrations.aspx.cs" inherits="CurrentRegistrations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/App_Themes/SiteStyles.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <div class="row vertical-margin">
        <div class="col-md-10 col-md-offset-1">
        <h3>The followings are your current registerations</h3>
        </div>
    </div>
    <div class="row vertical-margin">
         <div class="col-md-10 col-md-offset-1">
            <asp:Table runat="server" ID="tblCourses" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Course Title</asp:TableHeaderCell>
                <asp:TableHeaderCell>Weekly Hours</asp:TableHeaderCell>
                <asp:TableHeaderCell>&nbsp;</asp:TableHeaderCell>
            </asp:TableRow>
            </asp:Table>
        </div>
     </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
    <script>
        $(document).ready(function () {
            $(".deleteRegistration").on('click', function () {
                if (!confirm("Selected registration will be deleted!")) {
                    return false;
                }
            });
        });
    </script>
</asp:Content>

