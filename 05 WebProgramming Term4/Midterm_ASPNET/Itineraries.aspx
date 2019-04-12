<%@ page title="" language="C#" masterpagefile="~/ACMasterPage.master" autoeventwireup="true" codefile="Itineraries.aspx.cs" inherits="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Itineraries</h1>
        <br />
    <div class="row">
        <div class="col-md-2"><label for="drpPassenger">Passenger: </label></div>
        <div class="col-md-6"><asp:DropDownList ID="drpPassenger" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpPassenger_SelectedIndexChanged" Width="400px" ></asp:DropDownList></div>
    </div>
    <br />
        <div class="row">         
            <div class="col-md-6 col-md-offset-2"><h3>Outbound</h3></div>
        </div>
        <div class="row">
            <div class="col-md-2"><label for="txtOutboundDeparture">Departure City: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtOutboundDeparture" runat="server" CssClass="form-control" Width="400px"></asp:Textbox></div>
        </div>
        <div class="row">
            <div class="col-md-2"><label for="txtOutboundArriving">Arriving City: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtOutboundArriving" runat="server" CssClass="form-control" Width="400px"></asp:Textbox></div>
        </div>
        <div class="row">         
            <div class="col-md-6 col-md-offset-2"><h3>Return</h3></div>
        </div>
        <div class="row">
            <div class="col-md-2"><label for="txtReturnDeparture">Departure City: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtReturnDeparture" runat="server" CssClass="form-control" Width="400px"></asp:Textbox></div>
        </div>
        <div class="row">
            <div class="col-md-2"><label for="txtReturnArriving">Arriving City: </label></div>
            <div class="col-md-6"><asp:Textbox ID="txtReturnArriving" runat="server" CssClass="form-control" Width="400px"></asp:Textbox></div>
        </div>
        <div class="row">
            <div class="col-md-6 col-md-offset-2"><asp:button ID="btnSave" runat="server" CssClass="form-control btn-primary" Text="Save Changes" OnClick="btnSave_Click"></asp:button></div>
        </div>
        <div class="row">
            <div class="col-md-8"><asp:label ID="lblConfirmation" runat="server" CssClass="form-control alert-success"></asp:label></div>
        </div>   
</asp:Content>

