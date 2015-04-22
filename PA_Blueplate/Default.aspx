﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PA_Blueplate.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=12.0, minimum-scale=.25, user-scalable=no"/>
<script type="text/javascript" src="<%= ResolveUrl ("methods.js") %>"></script>
<link rel="stylesheet" href="style.css" />
    <title></title>

    <style>
            /*TO DELETE LATER SINCE IT IS IN STYLE.CSS. Sujay's use only!*/

        .fancy {
    text-align:center; 
    position: relative; min-height: 100%;
        padding: 20px 0 20px 0;
		 border: 4px solid white;
		 -webkit-border-radius: 12px;
		    -moz-border-radius: 12px;
		         border-radius: 12px;
		 /* Safari 4 does not support an inset shadow */
		 -webkit-box-shadow:       5px 5px 25px rgba(0,0,0,.5);
		 /* Chrome 5 does, Safari 4 will ignore this declaration */
		 -webkit-box-shadow: inset 5px 5px 25px rgba(0,0,0,.5);
		    -moz-box-shadow: inset 5px 5px 25px rgba(0,0,0,.5);
		         box-shadow: inset 5px 5px 25px rgba(0,0,0,.5);
		 font: 13px/20px "Arial";
		 background-color: #eee;
}
    </style>
</head> 
<!-- <body style=" margin:0px; width:330px;" > -->
<body>
    <form id="form1" runat="server">
        <!-- <div style="text-align: center;"> -->
          <!-- <div id="page-wrap"> -->
            <!-- <asp:Label ID="lblTitle" Text="Pennsylvania Department of General Services" runat="server" Font-Bold="true"  /> -->
           <!-- <h1> The Pennsylvania Department of General Services </h1> -->
            <div><asp:Image ID="Image0" runat="server" ImageUrl="img/generalserviceslogo_small.png" />
            </div>
            <div>
            <asp:Image ID="Image1" runat="server" Height="149px" Width="289px" ImageUrl="img/blueplate1.png" />
        </div>
        
        <div class="fancy">
            <asp:ImageButton ID="btnRepair" CommandArgument="Service_Vendors" ImageUrl="img/tools.png" OnClick="MyImgBtnHandler" runat="server"  Width="100" Height="100" />
            <asp:ImageButton ID="btnTowing" CommandArgument="Towing_Vendors" ImageUrl="img/towing.png" OnClick="MyImgBtnHandler" runat="server" Width="100" Height="100" />
            <asp:ImageButton ID="btnRental" CommandArgument="Tire_Vendors" ImageUrl="img/tire1.png" OnClick="MyImgBtnHandler" runat="server" Width="100" Height="100" />

        <div style="text-align: center;">
            <asp:Label ID="lblRepair" Text="Repair" runat="server" Width="100" Font-Bold="true" />
            <asp:Label ID="lblTowing" Text="Towing" runat="server" Width="100" Font-Bold="true" />
            <asp:Label ID="lblRental" Text="Tires" runat="server" Width="100" Font-Bold="true" />
        </div>
        <asp:HiddenField ID="hdnLatitude" runat="server" Value="lat" />
        <asp:HiddenField ID="hdnLongitude" runat="server" Value="long" />
        <asp:HiddenField ID="hdnOSType" runat="server" Value="OS" />
        


          <p><h2>Roadside Assistance</h2></p>
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">            
            <asp:TableRow>
                <asp:TableCell>
                <asp:ImageButton id="btnPhone" runat="server" ImageUrl="img/phone.png" OnClick="PhoneClick" Height="50" Width="50" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblPhone" Text="Ford: " runat="server" Font-Bold="true"  />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="phoneNumCall" Text="1.800.367.3221" runat="server" />
            </asp:TableCell>
        </asp:TableRow>

            <asp:TableRow>
               <asp:TableCell>
                 <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="img/phone.png" OnClick="PhoneClick" Height="50" Width="50" />
               </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label1" Text="GM: " runat="server" Font-Bold="true"  />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label2" Text="1.800.243.8872" runat="server" />
            </asp:TableCell>
        </asp:TableRow>


            <asp:TableRow>
                <asp:TableCell>
                <asp:ImageButton id="ImageButton2" runat="server" ImageUrl="img/phone.png" OnClick="PhoneClick" Height="50" Width="50" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label3" Text="Chrysler: " runat="server" Font-Bold="true"  />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="Label4" Text="1.800.864.3983" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        </asp:Table>
        </div>
           <p>Bureau of Vehicle Management Customer Service 
               <br />  
               <asp:ImageButton id="ImageButton3" runat="server" ImageUrl="img/phone.png" OnClick="PhoneClick" Height="50" Width="50" />
               <asp:Label ID="Label5" Text="877.347.9966" runat="server" />
               <br />

                <h3>or</h3>
              
                <asp:ImageButton id="ImageButton4" runat="server" ImageUrl="img/phone.png" OnClick="PhoneClick" Height="50" Width="50" />
               <asp:Label ID="Label6" Text="717.787.6034" runat="server" />  
               <br />
               Hours: Monday – Friday, 7:00 am to 5:00 pm</p>
    

        
    </form>

</body>
</html>
