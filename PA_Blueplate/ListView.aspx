<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListView.aspx.cs" Inherits="PA_Blueplate.ListView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PA Blueplate Application</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" />
    <div>
        <asp:Label id="label1" runat="server" Font-Bold="true"  />
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
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="img1" runat="server" ImageUrl="img/wrench.png" CommandArgument="MikesStation" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Mike's Station" Font-Size="X-Large" Font-Bold="true"/> 
                </asp:TableCell>
                <asp:TableCell RowSpan="2">
                    <asp:Label ID="Label3" runat="server" Text="3.2 mi" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label5" runat="server" Text="1234 Railroad Blvd, Harrisburg, PA 17110" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/wrench.png" CommandArgument="MikesStation" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label4" runat="server" Text="Ricky's Wrenches" Font-Size="X-Large" Font-Bold="true"/> 
                </asp:TableCell>
                <asp:TableCell RowSpan="2">
                    <asp:Label ID="Label6" runat="server" Text="5.6 mi" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label7" runat="server" Text="14 Adventure Bvld, Harrisburg, PA 17110" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="img/wrench.png" CommandArgument="MikesStation" OnClick="OnListItemClick" Height="50" Width="50" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label8" runat="server" Text="Speedy McFixIt" Font-Size="X-Large" Font-Bold="true"/> 
                </asp:TableCell>
                <asp:TableCell RowSpan="2">
                    <asp:Label ID="Label9" runat="server" Text="8.1 mi" /> 
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label10" runat="server" Text="2789 Ogre Rd, Enola, PA 17025" /> 
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </div>
    </form>
</body>
</html>
