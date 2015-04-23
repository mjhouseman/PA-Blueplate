using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Device.Location;

namespace PA_Blueplate
{
    public partial class Default : System.Web.UI.Page
    {
        string userOS, lat, lon;
        System.Device.Location.GeoCoordinateWatcher watcher;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get user location
            ScriptManager.RegisterStartupScript(this, this.GetType(), "GetUserLocation", "getLocation();", true);

            // Determine mobile device OS
            var userAgent = HttpContext.Current.Request.UserAgent.ToLower();
            if (userAgent.Contains("iphone") || userAgent.Contains("ipad"))
            {
                // iOS
                userOS = "iOS";
            }
            else if (userAgent.Contains("windows"))
            {
                // Windows
                userOS = "Windows";
            }
            else if (userAgent.Contains("android"))
            {
                // Android
                userOS = "Android";
            }
            else
            {
                userOS = "Other";
            }
        }

        protected void MyImgBtnHandler(object sender, EventArgs e)
        {
            string userLongitude = Request.Form["hdnLongitude"].ToString();
            string userLatitude = Request.Form["hdnLatitude"].ToString();
            string test = userOS;

            ImageButton btn = (ImageButton)sender;
            Response.Redirect("ListView.aspx?opt=" + btn.CommandArgument.ToString() + "&lon=" + userLongitude + "&lat=" + userLatitude + "&os=" + userOS, false);
        }

        public void PhoneClick(object sender, EventArgs e)
        {
            string num = "";
            ImageButton clickedButton = (ImageButton)sender;

            if (clickedButton == null)
                return;

            if (clickedButton.ID == "btnPhone1")
            {
                num = "tel:+18003673221";
            }
            else if (clickedButton.ID == "btnPhone2")
            {
                num = "tel:+18002438872";
            }
            else if (clickedButton.ID == "btnPhone3")
            {
                num = "tel:+18008643983";
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "phonecall", "window.open('" + num + "');", true);
        }
    }
}