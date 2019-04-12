<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <p>
        <asp:Label ID="schema" runat="server" Text="Schema"></asp:Label>
        :&nbsp;<asp:FileUpload ID="schemaUpload" runat="server" />
    </p>
    <p>
        <asp:Label ID="xml" runat="server" Text="Xml:"></asp:Label>
    &nbsp;<asp:FileUpload ID="xmlUpload" runat="server" />
    </p>
    <p>
        <asp:Button ID="validateBtn" runat="server" Text="Validate" OnClick="validateBtn_Click" />
    </p>
    <p>
        <asp:Label ID="testing" runat="server" ></asp:Label>
    </p>
    <div>
            <asp:Table runat="server" ID="validationResults" CssClass="table" Visible="false">
                <asp:TableRow>
                    <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Line#</asp:TableHeaderCell>    
                    <asp:TableHeaderCell>Column#</asp:TableHeaderCell> 
                    <asp:TableHeaderCell>Error Message</asp:TableHeaderCell> 
                </asp:TableRow>
            </asp:Table>
     </div>
    
</asp:Content>

