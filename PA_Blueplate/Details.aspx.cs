using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PA_Blueplate
{
    public partial class Details : System.Web.UI.Page
    {
        String userOS = null;
        String id, option, userLatitude, userLongitude;

        protected void Page_Load(object sender, EventArgs e)
        {


            id = !string.IsNullOrEmpty(Request.QueryString["id"]) ? Request.QueryString["id"] : "none";
            option = !string.IsNullOrEmpty(Request.QueryString["opt"]) ? Request.QueryString["opt"] : "none";
            userLatitude = !string.IsNullOrEmpty(Request.QueryString["lat"]) ? Request.QueryString["lat"] : "none";
            userLongitude = !string.IsNullOrEmpty(Request.QueryString["long"]) ? Request.QueryString["long"] : "none";
            userOS = !string.IsNullOrEmpty(Request.QueryString["os"]) ? Request.QueryString["os"] : "none";

            PopulatePage();
        }

        public void AddressClick(object sender, EventArgs e)
        {
            //894 Granville Street
            //Vancouver, BC V6Z 1K3               
            //http://maps.google.com/?saddr=Current%20Location&daddr= 894%20Granville%20Street%20Vancouver%20BC%20V6Z%201K3

            string url = "http://maps.google.com/?saddr=Current%20Location&daddr=" + lblAddress1Text.Text.ToString() + "%20" + lblCityText.Text.ToString() + "%20PA%20" + lblZipText.Text.ToString();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "open_window", string.Format("void(window.open('{0}', 'child_window'));", url), true);
        }

        public void PhoneClick(object sender, EventArgs e)
        {
            string tel = phoneNumCall.Text.ToString();
            tel = "tel:" + tel.Replace("-", "");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "dsadas", "window.open('" + tel + "');", true);
        }

        public void Phone24Click(object sender, EventArgs e)
        {
            string tel = phoneNum24Call.Text.ToString();
            tel = "tel:" + tel.Replace("-", "");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "dsadas", "window.open('" + tel + "');", true);
        }

        public void PopulatePage()
        {
            try
            {
                string connectionString = "Data Source=localhost;" + "initial catalog=PA_Blueplate_DB;" + "Integrated Security=SSPI;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT * FROM " + option + " WHERE ID = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //Save results into LocationItem and store in results array  
                                // Slight bug with Street_Address1 and State.... why??
                                switch (option)
                                {
                                    case "Towing_Vendors":
                                        lblCompany.Text = !string.IsNullOrEmpty(reader["Business_Name"].ToString()) ? reader["Business_Name"].ToString() : "";
                                        LblOtherName.Visible = !string.IsNullOrEmpty(reader["Other_Name"].ToString()) ? true : false;
                                        LblOtherNameText.Text = !string.IsNullOrEmpty(reader["Other_Name"].ToString()) ? reader["Other_Name"].ToString() : "";
                                        lblAddress1Text.Text = !string.IsNullOrEmpty(reader["Street_Address1"].ToString()) ? reader["Street_Address1"].ToString() : "";
                                        lblCityText.Text = !string.IsNullOrEmpty(reader["City"].ToString()) ? reader["City"].ToString() : "";
                                        lblZipText.Text = !string.IsNullOrEmpty(reader["Zip_Code"].ToString()) ? reader["Zip_Code"].ToString() : "";
                                        phoneNumCall.Text = !string.IsNullOrEmpty(reader["Phone"].ToString()) ? reader["Phone"].ToString() : "";
                                        btnPhone24.Visible = false;
                                        lblPhone247.Visible = false;
                                        phoneNum24Call.Visible = false;
                                        lblServices.Visible = false;
                                        tblServices.Visible = false;
                                        TireTable.Visible = false;
                                        break;
                                    case "Tire_Vendors":
                                        lblCompany.Text = !string.IsNullOrEmpty(reader["Business_Name"].ToString()) ? reader["Business_Name"].ToString() : "";
                                        LblOtherName.Visible = !string.IsNullOrEmpty(reader["Contact_Name"].ToString()) ? true : false;
                                        LblOtherName.Text = !string.IsNullOrEmpty(reader["Contact_Name"].ToString()) ? "Contact Name:" : "";
                                        LblOtherNameText.Text = !string.IsNullOrEmpty(reader["Contact_Name"].ToString()) ? reader["Contact_Name"].ToString() : "";
                                        lblAddress1Text.Text = !string.IsNullOrEmpty(reader["Street_Address1"].ToString()) ? reader["Street_Address1"].ToString() : "";
                                        lblCityText.Text = !string.IsNullOrEmpty(reader["City"].ToString()) ? reader["City"].ToString() : "";
                                        lblZipText.Text = !string.IsNullOrEmpty(reader["Zip_Code"].ToString()) ? reader["Zip_Code"].ToString() : "";
                                        phoneNumCall.Text = !string.IsNullOrEmpty(reader["Phone"].ToString()) ? reader["Phone"].ToString() : "";
                                        btnPhone24.Visible = false;
                                        lblPhone247.Visible = false;
                                        phoneNum24Call.Visible = false;
                                        lblServices.Visible = false;
                                        tblServices.Visible = false;
                                        TireTable.Visible = true;
                                        LblVendorNumberText.Text = !string.IsNullOrEmpty(reader["PA_Vendor_Number"].ToString()) ? reader["PA_Vendor_Number"].ToString() : "";
                                        LblVendorNumber.Visible = !string.IsNullOrEmpty(reader["PA_Vendor_Number"].ToString()) ? true : false;
                                        LblTireBrandText.Text = !string.IsNullOrEmpty(reader["Tire_Brand"].ToString()) ? reader["Tire_Brand"].ToString() : "";
                                        LblTireBrand.Visible = !string.IsNullOrEmpty(reader["Tire_Brand"].ToString()) ? true : false;
                                        LblDealerTypeText.Text = !string.IsNullOrEmpty(reader["Dealer_Type"].ToString()) ? reader["Dealer_Type"].ToString() : "";
                                        LblDealerType.Visible = !string.IsNullOrEmpty(reader["Dealer_Type"].ToString()) ? true : false;
                                        LblFaxText.Text = !string.IsNullOrEmpty(reader["Fax"].ToString()) ? reader["Fax"].ToString() : "";
                                        LblFax.Visible = !string.IsNullOrEmpty(reader["Fax"].ToString()) ? true : false;
                                        break;
                                    case "Service_Vendors":
                                        // ADD Street_Address2, 
                                        lblCompany.Text = !string.IsNullOrEmpty(reader["Business_Name"].ToString()) ? reader["Business_Name"].ToString() : "";
                                        LblOtherName.Visible = !string.IsNullOrEmpty(reader["Other_Name"].ToString()) ? true : false;
                                        LblOtherNameText.Text = !string.IsNullOrEmpty(reader["Other_Name"].ToString()) ? reader["Other_Name"].ToString() : "";
                                        LblOtherNameText.Visible = !string.IsNullOrEmpty(reader["Other_Name"].ToString()) ? true : false;
                                        lblAddress1Text.Text = !string.IsNullOrEmpty(reader["Street_Address1"].ToString()) ? reader["Street_Address1"].ToString() : "";
                                        lblCityText.Text = !string.IsNullOrEmpty(reader["City"].ToString()) ? reader["City"].ToString() : "";
                                        lblZipText.Text = !string.IsNullOrEmpty(reader["Zip_Code"].ToString()) ? reader["Zip_Code"].ToString() : "";
                                        phoneNumCall.Text = !string.IsNullOrEmpty(reader["Phone"].ToString()) ? reader["Phone"].ToString() : "";
                                        btnPhone24.Visible = !string.IsNullOrEmpty(reader["Towing_Phone_24"].ToString()) ? true : false;
                                        lblPhone247.Visible = !string.IsNullOrEmpty(reader["Towing_Phone_24"].ToString()) ? true : false;
                                        phoneNum24Call.Visible = !string.IsNullOrEmpty(reader["Towing_Phone_24"].ToString()) ? true : false;
                                        phoneNum24Call.Text = !string.IsNullOrEmpty(reader["Towing_Phone_24"].ToString()) ? reader["Towing_Phone_24"].ToString() : "";
                                        lblServices.Visible = true;
                                        tblServices.Visible = true;
                                        TireTable.Visible = false;
                                        lblBodyRepair.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblBodyRepairText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblBodyRepairRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblBodyRepairRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblBodyRepairRateText.Text = lblBodyRepair.Visible ? "$" + reader["Body_Repair_Rate"].ToString() + ".00" : "";

                                        lblBodyPartDiscount.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblBodyPartDiscountText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblBodyPartDiscountRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblBodyPartDiscountRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblBodyPartDiscountRateText.Text = lblBodyPartDiscount.Visible ? reader["Body_Part_Discount"].ToString() + "%" : "";

                                        lblComputerDiagnostics.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblComputerDiagnosticsRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblComputerDiagnosticsRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblComputerDiagnosticsText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblComputerDiagnosticsText.Text = lblComputerDiagnostics.Visible ? reader["Computer_Diagnostics"].ToString() : "";

                                        lblDiselLabor.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblDiselLaborRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblDiselLaborRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblDiselLaborText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblDiselLaborText.Text = lblDiselLabor.Visible ? reader["Disel_Labor"].ToString() : "";

                                        lblEmisionsInspection.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblEmisionsInspectionRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblEmisionsInspectionText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblEmisionsInspectionText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblEmisionsInspectionText.Text = lblEmisionsInspection.Visible ? reader["Emisions_Inspection"].ToString() : "";

                                        lblGlassRepair.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblGlassRepairRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblGlassRepairRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblGlassRepairText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblGlassRepairText.Text = lblGlassRepair.Visible ? reader["Glass_Repair"].ToString() : "";

                                        lblGlassPartsDiscount.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblGlassPartsDiscountRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblGlassPartsDiscountRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblGlassPartsDiscountText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblGlassPartsDiscountText.Text = lblGlassPartsDiscount.Visible ? reader["Glass_Repair"].ToString() : "";

                                        lblLubeOilChange.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblLubeOilChangeRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblLubeOilChangeRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblLubeOilChangeText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblLubeOilChangeText.Text = lblLubeOilChange.Visible ? reader["Lube_Oil_Change"].ToString() : "";

                                        lblSynLubeOilChange.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblSynLubeOilChangeText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblSynLubeOilChangeText.Text = lblSynLubeOilChange.Visible ? reader["Syn_Lube_Oil_Change"].ToString() : "";

                                        lblMechanicalLabor.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblMechanicalLaborRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblMechanicalLaborRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblMechanicalLaborText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblMechanicalLaborText.Text = lblMechanicalLabor.Visible ? reader["Mechanical_Labor"].ToString() : "";

                                        lblMechanicalParts.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblMechanicalPartsRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblMechanicalPartsRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblMechanicalPartsText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblMechanicalPartsText.Text = lblMechanicalParts.Visible ? reader["Mechanical_Parts"].ToString() : "";

                                        lblStateInspection.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblStateInspectionRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblStateInspectionRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblStateInspectionText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblStateInspectionText.Text = lblStateInspection.Visible ? reader["State_Inspection"].ToString() : "";

                                        lblTowing.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblTowingRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblTowingRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblTowingText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblTowingText.Text = lblTowing.Visible ? reader["Towing"].ToString() : "";

                                        lblTowing24.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblTowing24Text.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Repair"));
                                        lblTowing24Text.Text = lblTowing24.Visible ? reader["Towing_24"].ToString() : "";
                                       


                                        break;
                                }

                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}