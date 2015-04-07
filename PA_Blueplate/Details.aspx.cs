using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PA_Blueplate
{
    public partial class Details : System.Web.UI.Page
    {
        String userOS = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            String option, userLatitude, userLongitude;

            option = !string.IsNullOrEmpty(Request.QueryString["opt"]) ? Request.QueryString["opt"] : "none";
            userLatitude = !string.IsNullOrEmpty(Request.QueryString["lat"]) ? Request.QueryString["lat"] : "none";
            userLongitude = !string.IsNullOrEmpty(Request.QueryString["long"]) ? Request.QueryString["long"] : "none";
            userOS = !string.IsNullOrEmpty(Request.QueryString["os"]) ? Request.QueryString["os"] : "none";

            switch (option)
            {
                case "repairs" :
                    lblBodyPartDiscount.Visible = true;
                    lblBodyPartDiscountRate.Visible = true;
                    lblBodyPartDiscountRateText.Visible = true;
                    lblBodyPartDiscountText.Visible = true;
                    lblBodyRepair.Visible = true;
                    lblBodyRepairRate.Visible = true;
                    lblBodyRepairRateText.Visible = true;
                    lblBodyRepairText.Visible = true;
                    lblCityText.Visible = true;
                    break;
                case "towing" :
                    //lblPhone.Visible = false;
                    //lblPhoneText.Visible = false;
                    tblServices.Visible = false;
                    break;
                case "rental" :
                    LblOtherName.Visible = false;
                    LblOtherNameText.Visible = false;
                    tblServices.Visible = false;
                    break;
                default :
                    break;
            }
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
    }
}