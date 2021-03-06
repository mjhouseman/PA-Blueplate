﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="PA_Blueplate.ListView" CodeBehind="ListView.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PA Blueplate Application</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=12.0, minimum-scale=.25, user-scalable=no"/>
    <link rel="stylesheet" href="style.css" />

    <style>
            /*TO DELETE LATER SINCE IT IS IN STYLE.CSS. Sujay's use only!*/
.fancy {
    text-align:left; 
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

.button {
   border-top: 1px solid #96d1f8;
   background: #65a9d7;
   background: -webkit-gradient(linear, left top, left bottom, from(#3e779d), to(#65a9d7));
   background: -webkit-linear-gradient(top, #3e779d, #65a9d7);
   background: -moz-linear-gradient(top, #3e779d, #65a9d7);
   background: -ms-linear-gradient(top, #3e779d, #65a9d7);
   background: -o-linear-gradient(top, #3e779d, #65a9d7);
   padding: 6px 12px;
   -webkit-border-radius: 40px;
   -moz-border-radius: 40px;
   border-radius: 40px;
   -webkit-box-shadow: rgba(0,0,0,1) 0 1px 0;
   -moz-box-shadow: rgba(0,0,0,1) 0 1px 0;
   box-shadow: rgba(0,0,0,1) 0 1px 0;
   text-shadow: rgba(0,0,0,.4) 0 1px 0;
   color: white;
   font-size: 14px;
   font-family: Georgia, serif;
   text-decoration: none;
   vertical-align: middle;
   }

.button:hover {
   border-top-color: #28597a;
   background: #28597a;
   color: #ccc;
   }

.button:active {
   border-top-color: #1b435e;
   background: #1b435e;
   }
            

    </style>
</head>
<body>
     <asp:Image ID="Image1" runat="server" Height="65px" Width="121px" ImageUrl="img/blueplate1.png" />
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"  />
    <div>
        <asp:Label id="label1" runat="server" Font-Bold="true" Font-Size="X-Large" />
    </div>
    <div>
    <asp:Table runat="server" HorizontalAlign="Center">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:DropDownList id="dropdown" runat="server" OnSelectedIndexChanged="OnDropDownChange" AutoPostBack="true" Height="40"/>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">
                    <asp:TextBox ID="TxtManualLocation" runat="server" Height="40" />    
                    <asp:Button ID="Button1" runat="server" style="display:none" OnClick="OnManualLocationClick" Width="0" />
                </asp:Panel>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="BtnSetCurrentLocation" runat="server" OnClick="OnCurrentLocationClick" Text="Here" CssClass="FormatListviewButtons" Height="40" Width="40" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="BtnManualLocation" runat="server" OnClick="OnManualLocationClick" Text="Find" CssClass="FormatListviewButtons" Height="40" Width="40" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
                <asp:DropDownList id="RadiusDropDown" runat="server" OnSelectedIndexChanged="OnRadiusDropDownChange" AutoPostBack="true" Height="40" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>
    <div>
        <br />
        <div class="fancy" runat="server">
        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center" >
            <asp:TableRow runat="server" >
                <asp:TableCell RowSpan="2" >
                    <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="img/tools.png" CommandArgument="" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label11" runat="server" Font-Size="X-Large" Font-Bold="true" /> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label12" runat="server" Font-Bold="true" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label13" runat="server" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/tools.png" CommandArgument="" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="Label14" runat="server" Font-Size="X-Large" Font-Bold="true" /> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label15" runat="server" Font-Bold="true"/> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label16" runat="server" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="img/tools.png" CommandArgument="" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="Label17" runat="server" Font-Size="X-Large" Font-Bold="true" /> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label18" runat="server" Font-Bold="true"/> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label19" runat="server"  /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="img/tools.png" CommandArgument="" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="Label20" runat="server" Font-Size="X-Large" Font-Bold="true"/> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label21" runat="server" Font-Bold="true" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label22" runat="server"  /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="img/tools.png" CommandArgument="" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="Label23" runat="server"  Font-Size="X-Large" Font-Bold="true"/> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label24" runat="server" Font-Bold="true"/> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label25" runat="server"  />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:HiddenField ID="hdnTable" runat="server" />
        <asp:HiddenField ID="hdnWhere" runat="server" />
        <asp:HiddenField ID="hdnRadius" runat="server" />
        <asp:HiddenField ID="hdnLat" runat="server" Value="" />
        <asp:HiddenField ID="hdnLon" runat="server" Value="" />
    </div>
    <div>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Return to " />
        <a href="http://146.186.84.253/">Main Menu</a>
    </div>
    </div>
    </form>
    </body>
</html>
