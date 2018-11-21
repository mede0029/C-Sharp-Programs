<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SummerLab6.aspx.cs" Inherits="SummerLab6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Statistics Calculator</title>
</head>
<body>
        <form id="form1" runat="server" class="newStyle2" style="background-color: #C1E0FF">
      
        <h1>Statistics Calculator&nbsp;</h1>
        
        <div id="firstDiv">
            <p>&nbsp;Enter three numbers and click on <i>&quot;Submit&quot;</i> button to find out the statistics:</p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="firstNumber" runat="server" Text="First Number:" Font-bold="true"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="firstTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="secondNumber" runat="server" Text="Second Number:" Font-bold="true"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="secondTextBox" runat="server"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="thirdNumber" runat="server" Text="Third Number:" Font-bold="true"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="thirdTextBox" runat="server"></asp:TextBox>
        </div>

        <div id="secondDiv">
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="submitButton" runat="server" Text="Submit"/>
            <br />
            <asp:Label ID="errorMsg" runat="server" Text=" "  style="color: #FF0000" Font-Bold="true"></asp:Label>
            <br />
            <br />
        </div>

        <div id="thirdDiv">
            <p>Statistics of the numbers you entered: </p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="minimum" runat="server" Text="Minimum: " Font-bold="true"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="maximum" runat="server" Text="Maximum: " Font-bold="true"></asp:Label>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="averageLbl" runat="server" Text="Average: " Font-bold="true"></asp:Label>            
            <br />
            <br />            
            &nbsp;&nbsp;&nbsp;&nbsp;            
            <asp:Label ID="totalLbl" runat="server" Text="Total: " Font-bold="true"></asp:Label>
            <br />
        </div>
       
    </form>



</body>
</html>
