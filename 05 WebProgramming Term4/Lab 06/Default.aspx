<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #File1 {
            width: 305px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1>
        <asp:Label ID="Label1" runat="server" Text="Ottawa Restaurant Review"></asp:Label>
    </h1>
    <p>
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Search for restaurant(s) with rating above: "></asp:Label>
        &nbsp;&nbsp;<asp:TextBox id="initialRatingTxt" runat="server" />&nbsp;&nbsp;
        <asp:Button ID="submitBtn" runat="server" Text="Submit" OnClick="submitBtn_Click" /><br />
     <%--   <asp:Label ID="errorMsg" runat="server" Text="  No restaurant..." Font-Size="16px"  ></asp:Label>--%>
    </p>
    <asp:Literal ID="outputLiteral" runat="server"></asp:Literal>
    
</asp:Content>

