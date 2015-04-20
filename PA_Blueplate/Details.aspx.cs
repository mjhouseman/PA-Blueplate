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
                //string connectionString = "Data Source=localhost;" + "initial catalog=PA_Blueplate_DB;" + "Integrated Security=SSPI;";
                string connectionString = "Data Source=CMPSC488-SERVER.CS.HBG.PSU.EDU;Initial Catalog=PA_Blueplate_DB;User Id=MasterUser;Password=Blueplate$$20;";
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
                                        //lblAddress2.Visible = false;
                                        
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
                                       // lblAddress2.Visible = false;
                                        break;
                                    case "Service_Vendors":
                                        // ADD Street_Address2, 
                                        lblCompany.Text = !string.IsNullOrEmpty(reader["Business_Name"].ToString()) ? reader["Business_Name"].ToString() : "";
                                        LblOtherName.Visible = !string.IsNullOrEmpty(reader["Other_Name"].ToString()) ? true : false;
                                        LblOtherNameText.Text = !string.IsNullOrEmpty(reader["Other_Name"].ToString()) ? reader["Other_Name"].ToString() : "";
                                        LblOtherNameText.Visible = !string.IsNullOrEmpty(reader["Other_Name"].ToString()) ? true : false;
                                        lblAddress1Text.Text = !string.IsNullOrEmpty(reader["Street_Address1"].ToString()) ? reader["Street_Address1"].ToString() : "";
                                       // lblAddress2Text.Text = !string.IsNullOrEmpty(reader["Street_Address2"].ToString()) ? reader["Street_Address2"].ToString() : "";
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

                                        lblBodyPartDiscount.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Part")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Part"));
                                        lblBodyPartDiscountText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Part")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Part"));
                                        lblBodyPartDiscountRate.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Part")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Part"));
                                        lblBodyPartDiscountRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Body_Part")) ? false : reader.GetBoolean(reader.GetOrdinal("Body_Part"));
                                        lblBodyPartDiscountRateText.Text = lblBodyPartDiscount.Visible ? reader["Body_Part_Discount"].ToString() + "%" : "";

                                        lblComputerDiagnostics.Visible = reader.IsDBNull(reader.GetOrdinal("Computer_Diagnostics")) ? false : reader.GetBoolean(reader.GetOrdinal("Computer_Diagnostics"));
                                        lblComputerDiagnosticsRate.Visible = reader.IsDBNull(reader.GetOrdinal("Computer_Diagnostics")) ? false : reader.GetBoolean(reader.GetOrdinal("Computer_Diagnostics"));
                                        lblComputerDiagnosticsRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Computer_Diagnostics")) ? false : reader.GetBoolean(reader.GetOrdinal("Computer_Diagnostics"));
                                        lblComputerDiagnosticsText.Visible = reader.IsDBNull(reader.GetOrdinal("Computer_Diagnostics")) ? false : reader.GetBoolean(reader.GetOrdinal("Computer_Diagnostics"));
                                        lblComputerDiagnosticsRateText.Text = lblComputerDiagnostics.Visible ?"$"+ reader["Computer_Diagnostics_Rate"].ToString()+".00" : "";

                                        lblDieselLabor.Visible = reader.IsDBNull(reader.GetOrdinal("Diesel_Labor")) ? false : reader.GetBoolean(reader.GetOrdinal("Diesel_Labor"));
                                        lblDieselLaborRate.Visible = reader.IsDBNull(reader.GetOrdinal("Diesel_Labor")) ? false : reader.GetBoolean(reader.GetOrdinal("Diesel_Labor"));
                                        lblDieselLaborRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Diesel_Labor")) ? false : reader.GetBoolean(reader.GetOrdinal("Diesel_Labor"));
                                        lblDieselLaborText.Visible = reader.IsDBNull(reader.GetOrdinal("Diesel_Labor")) ? false : reader.GetBoolean(reader.GetOrdinal("Diesel_Labor"));
                                        lblDieselLaborRateText.Text = lblDieselLabor.Visible ? "$"+reader["Diesel_Labor_Rate"].ToString()+".00" : "";

                                        lblEmisionsInspection.Visible = reader.IsDBNull(reader.GetOrdinal("Emmissions_Inspections")) ? false : reader.GetBoolean(reader.GetOrdinal("Emmissions_Inspections"));
                                        lblEmisionsInspectionRate.Visible = reader.IsDBNull(reader.GetOrdinal("Emmissions_Inspections")) ? false : reader.GetBoolean(reader.GetOrdinal("Emmissions_Inspections"));
                                        lblEmisionsInspectionText.Visible = reader.IsDBNull(reader.GetOrdinal("Emmissions_Inspections")) ? false : reader.GetBoolean(reader.GetOrdinal("Emmissions_Inspections"));
                                        lblEmisionsInspectionRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Emmissions_Inspections")) ? false : reader.GetBoolean(reader.GetOrdinal("Emmissions_Inspections"));
                                        lblEmisionsInspectionRateText.Text = lblEmisionsInspection.Visible ?"$"+ reader["Emmissions_Inspections_Rate"].ToString()+".00" : "";

                                        lblGlassRepair.Visible = reader.IsDBNull(reader.GetOrdinal("Glass_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Glass_Repair"));
                                        lblGlassRepairRate.Visible = reader.IsDBNull(reader.GetOrdinal("Glass_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Glass_Repair"));
                                        lblGlassRepairRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Glass_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Glass_Repair"));
                                        lblGlassRepairText.Visible = reader.IsDBNull(reader.GetOrdinal("Glass_Repair")) ? false : reader.GetBoolean(reader.GetOrdinal("Glass_Repair"));
                                        lblGlassRepairRateText.Text = lblGlassRepair.Visible ?"$"+ reader["Glass_Repair_Rate"].ToString() +".00": "";

                                        lblGlassParts.Visible = reader.IsDBNull(reader.GetOrdinal("Glass_Parts")) ? false : reader.GetBoolean(reader.GetOrdinal("Glass_Parts"));
                                        lblGlassPartsDiscount.Visible = reader.IsDBNull(reader.GetOrdinal("Glass_Parts")) ? false : reader.GetBoolean(reader.GetOrdinal("Glass_Parts"));
                                        lblGlassPartsDiscountText.Visible = reader.IsDBNull(reader.GetOrdinal("Glass_Parts")) ? false : reader.GetBoolean(reader.GetOrdinal("Glass_Parts"));
                                        lblGlassPartsText.Visible = reader.IsDBNull(reader.GetOrdinal("Glass_Parts")) ? false : reader.GetBoolean(reader.GetOrdinal("Glass_Parts"));
                                        lblGlassPartsDiscountText.Text = lblGlassPartsDiscount.Visible ? reader["Glass_Parts_Discount"].ToString()+"%" : "";

                                        lblLubeOilChange.Visible = reader.IsDBNull(reader.GetOrdinal("Lube_Oil_Change")) ? false : reader.GetBoolean(reader.GetOrdinal("Lube_Oil_Change"));
                                        lblLubeOilChangeRate.Visible = reader.IsDBNull(reader.GetOrdinal("Lube_Oil_Change")) ? false : reader.GetBoolean(reader.GetOrdinal("Lube_Oil_Change"));
                                        lblLubeOilChangeRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Lube_Oil_Change")) ? false : reader.GetBoolean(reader.GetOrdinal("Lube_Oil_Change"));
                                        lblLubeOilChangeText.Visible = reader.IsDBNull(reader.GetOrdinal("Lube_Oil_Change")) ? false : reader.GetBoolean(reader.GetOrdinal("Lube_Oil_Change"));
                                        lblLubeOilChangeRateText.Text = lblLubeOilChange.Visible ?"$"+ reader["Lube_Oil_Change_Rate"].ToString()+".00" : "";
                                        lblSynLubeOilChangeText.Visible = reader.IsDBNull(reader.GetOrdinal("Lube_Oil_Change")) ? false : reader.GetBoolean(reader.GetOrdinal("Lube_Oil_Change"));                                  
                                        lblSynLubeOilChangeText.Text = lblSynLubeOilChange.Visible ? "$"+reader["Syn_Lube_Oil_Change_Rate"].ToString() +".00" : "";

                                        lblMechanicalLabor.Visible = reader.IsDBNull(reader.GetOrdinal("Mechanical_Labor")) ? false : reader.GetBoolean(reader.GetOrdinal("Mechanical_Labor"));
                                        lblMechanicalLaborRate.Visible = reader.IsDBNull(reader.GetOrdinal("Mechanical_Labor")) ? false : reader.GetBoolean(reader.GetOrdinal("Mechanical_Labor"));
                                        lblMechanicalLaborRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Mechanical_Labor")) ? false : reader.GetBoolean(reader.GetOrdinal("Mechanical_Labor"));
                                        lblMechanicalLaborText.Visible = reader.IsDBNull(reader.GetOrdinal("Mechanical_Labor")) ? false : reader.GetBoolean(reader.GetOrdinal("Mechanical_Labor"));
                                        lblMechanicalLaborRateText.Text = lblMechanicalLabor.Visible ?"$" +reader["Mechanical_Labor_Rate"].ToString()+".00" : "";

                                        lblMechanicalParts.Visible = reader.IsDBNull(reader.GetOrdinal("Mechanical_Parts")) ? false : reader.GetBoolean(reader.GetOrdinal("Mechanical_Parts"));
                                        lblMechanicalPartsRate.Visible = reader.IsDBNull(reader.GetOrdinal("Mechanical_Parts")) ? false : reader.GetBoolean(reader.GetOrdinal("Mechanical_Parts"));
                                        lblMechanicalPartsRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Mechanical_Parts")) ? false : reader.GetBoolean(reader.GetOrdinal("Mechanical_Parts"));
                                        lblMechanicalPartsText.Visible = reader.IsDBNull(reader.GetOrdinal("Mechanical_Parts")) ? false : reader.GetBoolean(reader.GetOrdinal("Mechanical_Parts"));
                                        lblMechanicalPartsRateText.Text = lblMechanicalParts.Visible ? reader["Mechanical_Parts_Discount"].ToString()+"%" : "";

                                        lblStateInspection.Visible = reader.IsDBNull(reader.GetOrdinal("State_Inspection")) ? false : reader.GetBoolean(reader.GetOrdinal("State_Inspection"));
                                        lblStateInspectionRate.Visible = reader.IsDBNull(reader.GetOrdinal("State_Inspection")) ? false : reader.GetBoolean(reader.GetOrdinal("State_Inspection"));
                                        lblStateInspectionRateText.Visible = reader.IsDBNull(reader.GetOrdinal("State_Inspection")) ? false : reader.GetBoolean(reader.GetOrdinal("State_Inspection"));
                                        lblStateInspectionText.Visible = reader.IsDBNull(reader.GetOrdinal("State_Inspection")) ? false : reader.GetBoolean(reader.GetOrdinal("State_Inspection"));
                                        lblStateInspectionRateText.Text = lblStateInspection.Visible ? "$"+ reader["State_Inspection_Rate"].ToString()+".00" : "";

                                        lblTowing.Visible = reader.IsDBNull(reader.GetOrdinal("Towing")) ? false : reader.GetBoolean(reader.GetOrdinal("Towing"));
                                        lblTowingRate.Visible = reader.IsDBNull(reader.GetOrdinal("Towing")) ? false : reader.GetBoolean(reader.GetOrdinal("Towing"));
                                        lblTowingRateText.Visible = reader.IsDBNull(reader.GetOrdinal("Towing")) ? false : reader.GetBoolean(reader.GetOrdinal("Towing"));
                                        lblTowingText.Visible = reader.IsDBNull(reader.GetOrdinal("Towing")) ? false : reader.GetBoolean(reader.GetOrdinal("Towing"));
                                        lblTowingRateText.Text = lblTowing.Visible ? "$"+ reader["Towing_Rate"].ToString()+".00" : "";

                                        lblTowing24.Visible = reader.IsDBNull(reader.GetOrdinal("Towing_24")) ? false : reader.GetBoolean(reader.GetOrdinal("Towing_24"));
                                        lblTowing24Text.Visible = reader.IsDBNull(reader.GetOrdinal("Towing_24")) ? false : reader.GetBoolean(reader.GetOrdinal("Towing_24"));
                                       // lblTowing24Text.Text = lblTowing24.Visible ? reader["Towing_24"].ToString() : "";
                                       


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