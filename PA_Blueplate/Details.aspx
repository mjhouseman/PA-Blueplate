<%@ Page Language="C#" AutoEventWireup="true" Inherits="PA_Blueplate.Details" CodeBehind="Details.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=12.0, minimum-scale=.25, user-scalable=no"/>
<link rel="stylesheet" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblCompany" Text="BOCHEK AUTO BODY INC" runat="server" Font-Bold="true"  />
        <br />
    </div>
    <div>
        <br />
        <asp:Label ID="LblOtherName" Text="Other Name: " runat="server" Font-Bold="true"  />
        <asp:Label ID="LblOtherNameText" Text="BOCHEK'S COLLISION CENTER" runat="server" />
        <br />
        <asp:Table runat="server">

            <asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="img/address.png" OnClick="AddressClick" Height="50" Width="50" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblAddress1" Text="Address: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblAddress1Text" Text="1009 RUSSELLTON ROAD" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:Label runat="server"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblCityText" Text="CHESWICK" runat="server" />, PA <asp:Label ID="lblZipText" Text="15024" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:ImageButton id="btnPhone" runat="server" ImageUrl="img/phone.gif" OnClick="PhoneClick" Height="50" Width="50" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblPhone" Text="Telephone: " runat="server" Font-Bold="true"  />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="phoneNumCall" Text="724-274-5755" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell >
                    <asp:ImageButton id="btnPhone24" runat="server" ImageUrl="img/phone.gif" OnClick="Phone24Click" Height="50" Width="50" />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="lblPhone247" Text="24/7 Telephone: " runat="server" Font-Bold="true"  />
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="phoneNum24Call" Text="724-274-5755" runat="server" />
            </asp:TableCell> 
        </asp:TableRow>
        </asp:Table>
    </div>
    <div>
        <br />
        <asp:Label ID="lblServices" Text="Services" runat="server" Font-Bold="true"  />
        <asp:Table ID="tblServices" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBodyRepair" Text="Body Repair: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblBodyRepairText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBodyRepairRate" Text="Body Repair Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblBodyRepairRateText" Text="46" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBodyPartDiscount" Text="Body Part Discount: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblBodyPartDiscountText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblBodyPartDiscountRate" Text="Body Part Discount Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblBodyPartDiscountRateText" Text="15%" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblComputerDiagnostics" Text="Computer Diagnostics: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblComputerDiagnosticsText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblComputerDiagnosticsRate" Text="Computer Diagnostics Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblComputerDiagnosticsRateText" Text="52" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label1" Text="Diesel Labor: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label2" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label3" Text="Diesel Labor Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label4" Text="53" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label5" Text="Emisions Inspections: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label6" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label7" Text="Emmisions Inspections Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label8" Text="31" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label9" Text="Glass Repair: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label10" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label11" Text="Glass Repair Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label12" Text="39" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label13" Text="Glass Parts Discount: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label14" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label15" Text="Glass Parts Discount Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label16" Text="20%" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label17" Text="Lube / Oil Change: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label18" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label19" Text="Lube / Oil Change Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label20" Text="29" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label21" Text="Syn Lube / Oil Change: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label22" Text="50" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label23" Text="Mechanical Labor: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label24" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label25" Text="Mechanical Labor Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label26" Text="55" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label27" Text="Mechanical Parts: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label28" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label29" Text="Mechanical Parts Discount Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label30" Text="15%" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label31" Text="State Inspection: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label32" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label33" Text="State Inspection Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label34" Text="25" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label35" Text="Towing: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label36" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label37" Text="Towing Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label38" Text="110" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label39" Text="24/7 Towing: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="Label40" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="TireTable" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LblVendorNumber" Text="PA Vendor Number:" runat="server" Font-Bold="true" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LblVendorNumberText" Text="0000" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LblDealerType" Text="Dealer Type:" runat="server" Font-Bold="true" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LblDealerTypeText" Text="xxxx" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LblTireBrand" Text="Tire Brand:" runat="server" Font-Bold="true" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LblTireBrandText" Text="xxxx" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LblFax" Text="Fax:" runat="server" Font-Bold="true" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="LblFaxText" Text="xxxx" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
