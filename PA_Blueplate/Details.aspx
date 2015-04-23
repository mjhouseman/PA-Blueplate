<%@ Page Language="C#" AutoEventWireup="true" Inherits="PA_Blueplate.Details" CodeBehind="Details.aspx.cs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=12.0, minimum-scale=.25, user-scalable=no" />
    <link rel="stylesheet" href="style.css" />
    <style>
        /*TO DELETE LATER SINCE IT IS IN STYLE.CSS. Sujay's use only!*/
        .fancy {
            text-align: left;
            position: relative;
            min-height: 100%;
            border: 4px solid white;
            padding: 20px 0 20px 0;
            -webkit-border-radius: 12px;
            -moz-border-radius: 12px;
            border-radius: 12px;
            /* Safari 4 does not support an inset shadow */
            -webkit-box-shadow: 5px 5px 25px rgba(0,0,0,.5);
            /* Chrome 5 does, Safari 4 will ignore this declaration */
            -webkit-box-shadow: inset 5px 5px 25px rgba(0,0,0,.5);
            -moz-box-shadow: inset 5px 5px 25px rgba(0,0,0,.5);
            box-shadow: inset 5px 5px 25px rgba(0,0,0,.5);
            font: 13px/20px "Arial";
            background-color: #eee;
        }

        .T {
            text-align: center;
        }
    </style>
</head>
<body>
    <asp:Image ID="Image1" runat="server" Height="65px" Width="121px" ImageUrl="img/blueplate1.png" />
    <form id="form1" runat="server">
  
            <div class="T">
                <asp:Label ID="lblCompany" Text="BOCHEK AUTO BODY INC" runat="server" Font-Bold="true" Font-Size="X-Large" />
                <br />
                
            </div>
        <br />
        <div class="fancy">
            <div>
                <div class="T" id="dvOtherName">
                    <br />
                    <asp:Label ID="LblOtherName" Text="Other Name: " runat="server" Font-Bold="true"  />
                    <asp:Label ID="LblOtherNameText" Text="BOCHEK'S COLLISION CENTER" runat="server"  />
                    <br />
                 </div>
                <asp:Table ID="Table1" runat="server" HorizontalAlign="Center">
                    <asp:TableRow ID="trAddress1">
                        <asp:TableCell RowSpan="3" ID="tcAddressImage">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="img/travel_directions.png" OnClick="AddressClick" Height="50" Width="50" />
                        </asp:TableCell>
                        <asp:TableCell RowSpan="3" ID="tcAddressLabel">
                            <asp:Label ID="lblAddress1" Text="Address: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:Label ID="lblAddress1Text" Text="1009 RUSSELLTON ROAD" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trAddress2">
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:Label ID="lblAddress2Text" Text="Address2" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Left">
                            <asp:Label ID="lblCityText" Text="CHESWICK" runat="server" />, PA
                            <asp:Label ID="lblZipText" Text="15024" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:ImageButton ID="btnPhone" runat="server" ImageUrl="img/phone.png" OnClick="PhoneClick" Height="50" Width="50" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblPhone" Text="Telephone: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="phoneNumCall" Text="724-274-5755" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:ImageButton ID="btnPhone24" runat="server" ImageUrl="img/phone.png" OnClick="Phone24Click" Height="50" Width="50" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblPhone247" Text="24/7 Telephone: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="phoneNum24Call" Text="724-274-5755" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div>
                <br />


                <asp:Table ID="tblServices" runat="server" HorizontalAlign="Center" >
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblServices" Text="Services:" runat="server" Font-Bold="true" Font-Size="Medium" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trBodyRepair">
                        <asp:TableCell>
                            <asp:Label ID="lblBodyRepair" Text="Body Repair: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblBodyRepairText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trBodyRepairRate">
                        <asp:TableCell>
                            <asp:Label ID="lblBodyRepairRate" Text="Body Repair Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblBodyRepairRateText" Text="46" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trBodyPartDiscount">
                        <asp:TableCell>
                            <asp:Label ID="lblBodyPartDiscount" Text="Body Part Discount: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblBodyPartDiscountText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trBodyPartDiscountRate">
                        <asp:TableCell>
                            <asp:Label ID="lblBodyPartDiscountRate" Text="Body Part Discount Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblBodyPartDiscountRateText" Text="15%" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trComputerDiagnostics">
                        <asp:TableCell>
                            <asp:Label ID="lblComputerDiagnostics" Text="Computer Diagnostics: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblComputerDiagnosticsText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trComputerDiagnosticsRate">
                        <asp:TableCell>
                            <asp:Label ID="lblComputerDiagnosticsRate" Text="Computer Diagnostics Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblComputerDiagnosticsRateText" Text="52" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trDieselLabor">
                        <asp:TableCell>
                            <asp:Label ID="lblDieselLabor" Text="Diesel Labor: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblDieselLaborText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trDieselLaborRate">
                        <asp:TableCell>
                            <asp:Label ID="lblDieselLaborRate" Text="Diesel Labor Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblDieselLaborRateText" Text="53" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trEmissionsInspection">
                        <asp:TableCell>
                            <asp:Label ID="lblEmisionsInspection" Text="Emisions Inspections: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblEmisionsInspectionText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trEmisionsInspectionRate">
                        <asp:TableCell>
                            <asp:Label ID="lblEmisionsInspectionRate" Text="Emmisions Inspections Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblEmisionsInspectionRateText" Text="31" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trGlassRepair">
                        <asp:TableCell>
                            <asp:Label ID="lblGlassRepair" Text="Glass Repair: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblGlassRepairText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trGlassRepairRate">
                        <asp:TableCell>
                            <asp:Label ID="lblGlassRepairRate" Text="Glass Repair Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblGlassRepairRateText" Text="39" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trGlassParts">
                        <asp:TableCell>
                            <asp:Label ID="lblGlassParts" Text="Glass Parts: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblGlassPartsText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trGlassPartsDiscount">
                        <asp:TableCell>
                            <asp:Label ID="lblGlassPartsDiscount" Text="Glass Parts Discount : " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblGlassPartsDiscountText" Text="20%" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trLubeOilChange">
                        <asp:TableCell>
                            <asp:Label ID="lblLubeOilChange" Text="Lube / Oil Change: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblLubeOilChangeText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trLubeOilChangeRate">
                        <asp:TableCell>
                            <asp:Label ID="lblLubeOilChangeRate" Text="Lube / Oil Change Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblLubeOilChangeRateText" Text="29" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trSynLubeOilChange">
                        <asp:TableCell>
                            <asp:Label ID="lblSynLubeOilChange" Text="Syn Lube / Oil Change: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblSynLubeOilChangeText" Text="50" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trMechanicalLabor">
                        <asp:TableCell>
                            <asp:Label ID="lblMechanicalLabor" Text="Mechanical Labor: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblMechanicalLaborText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trMechanicalLaborRate">
                        <asp:TableCell>
                            <asp:Label ID="lblMechanicalLaborRate" Text="Mechanical Labor Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblMechanicalLaborRateText" Text="55" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trMechanicalParts">
                        <asp:TableCell>
                            <asp:Label ID="lblMechanicalParts" Text="Mechanical Parts: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblMechanicalPartsText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trMechanicalPartsRate">
                        <asp:TableCell>
                            <asp:Label ID="lblMechanicalPartsRate" Text="Mechanical Parts Discount Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblMechanicalPartsRateText" Text="15%" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trStateInspection">
                        <asp:TableCell>
                            <asp:Label ID="lblStateInspection" Text="State Inspection: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblStateInspectionText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trStateInspectionRate">
                        <asp:TableCell>
                            <asp:Label ID="lblStateInspectionRate" Text="State Inspection Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblStateInspectionRateText" Text="25" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trTowing">
                        <asp:TableCell>
                            <asp:Label ID="lblTowing" Text="Towing: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblTowingText" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trTowingRate">
                        <asp:TableCell>
                            <asp:Label ID="lblTowingRate" Text="Towing Rate: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblTowingRateText" Text="110" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow ID="trTowing24">
                        <asp:TableCell>
                            <asp:Label ID="lblTowing24" Text="24/7 Towing: " runat="server" Font-Bold="true" />
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblTowing24Text" Text="Accepted" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br/>
                <asp:Table ID="TireTable" runat="server" HorizontalAlign="Center">
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
        </div>
        <p>
            Return to <a href="http://146.186.84.253/">Main Menu
                
        </a>
            </p>
    </form>
</body>
</html>
