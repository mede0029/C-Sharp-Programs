<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h1>
        <asp:Label ID="Label1" runat="server" Text="Restaurant Review"></asp:Label>
    </h1>
    <p>
        <asp:Label ID="restaurantLbl" runat="server" Text="Restaurant:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="restaurantDropDown" AutoPostBack="true" runat="server" OnSelectedIndexChanged="restaurantDropDown_SelectedIndexChanged">
            <asp:ListItem Value="0">Select one...</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="addressLbl" runat="server" Text="Address:" Visible="false"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="addressTxt" runat="server" Visible="false" TextMode="MultiLine" Height="86px" Width="253px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="summaryLbl" runat="server" Text="Summary:" Visible="false"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:TextBox ID="summaryTxt" runat="server" Visible="false" TextMode="MultiLine" Height="190px" Width="437px"  ></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="ratingLbl" runat="server" Text="Rating:" Visible="false"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ratingDropDown" runat="server" Visible="false">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="saveBtn" runat="server" Visible="false" Text="Save Changes" OnClick="saveBtn_Click" />
    </p>
    <p style="color:forestgreen; background-color:powderblue">
        <asp:Label ID="messageLbl" runat="server" Text="" Font-Size="14px" visible="false" ></asp:Label>
    </p>
    <div>
     </div>
    
</asp:Content>

