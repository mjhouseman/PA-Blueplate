<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="PA_Blueplate.Default" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style=" margin:0px; width:330px;" >
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <asp:Label ID="lblTitle" Text="Pennsylvania Department of General Services" runat="server" Font-Bold="true"  />
        </div>
        <div>
            <asp:Image ID="Image1" runat="server" Height="220px" Width="300px" ImageUrl="img/blueplate1.jpg" />
        </div>
        <div>
            <asp:ImageButton ID="btnRepair" CommandArgument="Repair Stations" ImageUrl="img/wrench.png" OnClick="MyImgBtnHandler" runat="server"  Width="100" Height="100" />
            <asp:ImageButton ID="btnTowing" CommandArgument="Towing Centers" ImageUrl="img/towtruck.jpg" OnClick="MyImgBtnHandler" runat="server" Width="100" Height="100" />
            <asp:ImageButton ID="btnRental" CommandArgument="Tire Services" ImageUrl="img/tire.png" OnClick="MyImgBtnHandler" runat="server" Width="100" Height="100" />
        </div>  
        <div style="text-align: center;">
            <asp:Label ID="lblRepair" Text="Repair" runat="server" Width="100" Font-Bold="true" />
            <asp:Label ID="lblTowing" Text="Towing" runat="server" Width="100" Font-Bold="true" />
            <asp:Label ID="lblRental" Text="Tires" runat="server" Width="100" Font-Bold="true" />
        </div>
    </form>
</body>
</html>
