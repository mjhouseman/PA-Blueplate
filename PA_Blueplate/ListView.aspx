<%@ Page Language="C#" AutoEventWireup="true" Inherits="PA_Blueplate.ListView" CodeBehind="ListView.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PA Blueplate Application</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=12.0, minimum-scale=.25, user-scalable=no"/>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
     <asp:Image ID="Image1" runat="server" Height="65px" Width="121px" ImageUrl="img/blueplate1.jpg" />
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <div>
        <asp:Label id="label1" runat="server" Font-Bold="true" OnClick= "OnListItemClick" />
    </div>
    <div>
        <asp:DropDownList id="dropdown" runat="server" OnSelectedIndexChanged="OnDropDownChange" AutoPostBack="true" >
        </asp:DropDownList>
    </div>
    <div>
        
        <br />
        <%-- 
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1"> 
            <LayoutTemplate> 
                <table id="Table1" runat="server" class="TableCSS"> 
                    <tr id="ItemPlaceholder" runat="server" onclick="onListItemClick"> 
                    </tr> 
                    <tr id="Tr2" runat="server"> 
                        <td id="Td6" runat="server" colspan="2"> 
                            <asp:DataPager ID="DataPager1" runat="server"> 
                                <Fields> 
                                    <asp:NextPreviousPagerField ButtonType="Link" /> 
                                    <asp:NumericPagerField /> 
                                    <asp:NextPreviousPagerField ButtonType="Link" /> 
                                </Fields> 
                            </asp:DataPager> 
                        </td> 
                    </tr> 
                </table> 
            </LayoutTemplate> 
            <ItemTemplate> 
                <tr class="TableData"> 
                    <td> 
                        <asp:Label ID="Label1" runat="server" Text="Mike's Station                " Font-Size="Large" Font-Bold="true"/> 
                    </td> 
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="3.2 mi" />
                    </td>
                </tr>
                <tr>
                    <td> 
                        <asp:Label ID="Label2" runat="server" Text="1234 Railroad Blvd, Harrisburg, PA 17110          "> 
                        </asp:Label> 
                    </td>  
                </tr>                 
            </ItemTemplate> 
              
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:BlogEngineConnectionString %>" SelectCommand="SELECT * FROM [Comments]"></asp:SqlDataSource>
        --%>

        <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
            <asp:TableRow runat="server" OnClick = "OnListItemClick">
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="img/tools.png" CommandArgument="MikesStation" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label11" runat="server" Text="A-B-E Car Care Center LLC" Font-Size="X-Large" Font-Bold="true" OnClick= "OnListItemClick"/> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label12" runat="server" Text="3.2 mi" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label13" runat="server" Text="1302 W Tilghman Street, Allentown, PA 18102" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/tools.png" CommandArgument="MikesStation" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="Label14" runat="server" Text="Modi Moters LLC" Font-Size="X-Large" Font-Bold="true" OnClick= "OnListItemClick"/> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label15" runat="server" Text="5.6 mi" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label16" runat="server" Text="2530 Walnut Street, Harrisburg, PA 17103" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="img/tools.png" CommandArgument="MikesStation" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="Label17" runat="server" Text="Rabold's Services" Font-Size="X-Large" Font-Bold="true" OnClick= "OnListItemClick"/> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label18" runat="server" Text="8.1 mi" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label19" runat="server" Text="2034 Boas Street, Harrisburg, PA 17103" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="img/tools.png" CommandArgument="MikesStation" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="Label20" runat="server" Text="Rick's Auto Body" Font-Size="X-Large" Font-Bold="true" OnClick= "OnListItemClick"/> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label21" runat="server" Text="9.24 mi" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label22" runat="server" Text="1114 N Cameron Street, Harrisburg, PA 17103" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="img/tools.png" CommandArgument="MikesStation" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell><asp:TableCell>
                    <asp:Label ID="Label23" runat="server" Text="Buchek Auto Body Inc" Font-Size="X-Large" Font-Bold="true" OnClick= "OnListItemClick"/> 
                </asp:TableCell><asp:TableCell RowSpan="2">
                    <asp:Label ID="Label24" runat="server" Text="15.7 mi" /> 
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label25" runat="server" Text="1009 Russellton Road, Cheswick, PA 15024" />
                </asp:TableCell></asp:TableRow></asp:Table>
                <p><h2>Return to <a href="http://146.186.84.253/"> Main Menu</h2></a>
                </div></form></body></html>
