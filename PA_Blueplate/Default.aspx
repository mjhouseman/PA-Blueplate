<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PA_Blueplate.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=12.0, minimum-scale=.25, user-scalable=no"/>
<script type="text/javascript" src="<%= ResolveUrl ("methods.js") %>"></script>
<link rel="stylesheet" href="style.css" />
    <title></title>
</head> 
<!-- <body style=" margin:0px; width:330px;" > -->
<body>
    <form id="form1" runat="server">
        <!-- <div style="text-align: center;"> -->
          <!-- <div id="page-wrap"> -->
            <!-- <asp:Label ID="lblTitle" Text="Pennsylvania Department of General Services" runat="server" Font-Bold="true"  /> -->
           <!-- <h1> The Pennsylvania Department of General Services </h1> -->
            <div><asp:Image ID="Image0" runat="server" ImageUrl="img/generalserviceslogo_small.png" />
        
        
            <asp:Image ID="Image1" runat="server" Height="220px" Width="300px" ImageUrl="img/blueplate1.jpg" />
        </div>
        <div>
            <asp:ImageButton ID="btnRepair" CommandArgument="Service_Vendors" ImageUrl="img/wrench.png" OnClick="MyImgBtnHandler" runat="server"  Width="100" Height="100" />
            <asp:ImageButton ID="btnTowing" CommandArgument="Towing_Vendors" ImageUrl="img/towing.png" OnClick="MyImgBtnHandler" runat="server" Width="100" Height="100" />
            <asp:ImageButton ID="btnRental" CommandArgument="Tire_Vendors" ImageUrl="img/tire1.png" OnClick="MyImgBtnHandler" runat="server" Width="100" Height="100" />
        </div>  
        <div style="text-align: center;">
            <asp:Label ID="lblRepair" Text="Repair" runat="server" Width="100" Font-Bold="true" />
            <asp:Label ID="lblTowing" Text="Towing" runat="server" Width="100" Font-Bold="true" />
            <asp:Label ID="lblRental" Text="Tires" runat="server" Width="100" Font-Bold="true" />
        </div>
        <asp:HiddenField ID="hdnLatitude" runat="server" Value="lat" />
        <asp:HiddenField ID="hdnLongitude" runat="server" Value="long" />
        <asp:HiddenField ID="hdnOSType" runat="server" Value="OS" />
        <asp:Label ID="lblGPSAvailability" runat="server" Text="Please enable JavaScript" />

    </form>
    
</body>
</html>
