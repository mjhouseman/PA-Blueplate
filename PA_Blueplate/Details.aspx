<%@ Page Language="C#" AutoEventWireup="true" Inherits="PA_Blueplate.Details" CodeBehind="Details.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=12.0, minimum-scale=.25, user-scalable=no"/>
<!-- <link rel="stylesheet" href="style.css" /> -->
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
        <asp:Table ID="Table1" runat="server">

            <asp:TableRow>
                <asp:TableCell RowSpan="2">
                    <asp:ImageButton id="ImageButton1" runat="server" ImageUrl="img/travel_directions.png" OnClick="AddressClick" Height="50" Width="50" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblAddress1" Text="Address: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblAddress1Text" Text="1009 RUSSELLTON ROAD" runat="server" />
                </asp:TableCell>
              
            </asp:TableRow>
            
            <asp:TableRow>
                <asp:TableCell><asp:Label ID="Label1" runat="server"></asp:Label></asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblCityText" Text="CHESWICK" runat="server" />, PA <asp:Label ID="lblZipText" Text="15024" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:ImageButton id="btnPhone" runat="server" ImageUrl="img/phone.png" OnClick="PhoneClick" Height="50" Width="50" />
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
                    <asp:ImageButton id="btnPhone24" runat="server" ImageUrl="img/phone.png" OnClick="Phone24Click" Height="50" Width="50" />
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
                    <asp:Label ID="lblDieselLabor" Text="Diesel Labor: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDieselLaborText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblDieselLaborRate" Text="Diesel Labor Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblDieselLaborRateText" Text="53" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmisionsInspection" Text="Emisions Inspections: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblEmisionsInspectionText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblEmisionsInspectionRate" Text="Emmisions Inspections Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblEmisionsInspectionRateText" Text="31" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGlassRepair" Text="Glass Repair: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblGlassRepairText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGlassRepairRate" Text="Glass Repair Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblGlassRepairRateText" Text="39" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGlassParts" Text="Glass Parts: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblGlassPartsText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblGlassPartsDiscount" Text="Glass Parts Discount : " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblGlassPartsDiscountText" Text="20%" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblLubeOilChange" Text="Lube / Oil Change: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblLubeOilChangeText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblLubeOilChangeRate" Text="Lube / Oil Change Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblLubeOilChangeRateText" Text="29" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblSynLubeOilChange" Text="Syn Lube / Oil Change: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblSynLubeOilChangeText" Text="50" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMechanicalLabor" Text="Mechanical Labor: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblMechanicalLaborText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMechanicalLaborRate" Text="Mechanical Labor Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblMechanicalLaborRateText" Text="55" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMechanicalParts" Text="Mechanical Parts: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblMechanicalPartsText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblMechanicalPartsRate" Text="Mechanical Parts Discount Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblMechanicalPartsRateText" Text="15%" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblStateInspection" Text="State Inspection: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblStateInspectionText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblStateInspectionRate" Text="State Inspection Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblStateInspectionRateText" Text="25" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTowing" Text="Towing: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblTowingText" Text="Accepted" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTowingRate" Text="Towing Rate: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblTowingRateText" Text="110" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="lblTowing24" Text="24/7 Towing: " runat="server" Font-Bold="true"  />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblTowing24Text" Text="Accepted" runat="server" />
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
