using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PA_Blueplate
{
    public partial class Default : System.Web.UI.Page
    {
        string userOS;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get user location
            ScriptManager.RegisterStartupScript(this, this.GetType(), "GetUserLocation", "getLocation()", true);

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
            //string test = hdnOSType.Value;
            //string userLongitude2 = hdnLongitude.Value;
            //string userLatitude2 = hdnLatitude.Value;
            string userLongitude = Request.Form["hdnLongitude"];
            string userLatitude = Request.Form["hdnLatitude"];
            //string userOS = Request.Form["hdnOSType"];
            //hdnLatitude.Value = "dd";
            string test = userOS;

            ImageButton btn = (ImageButton)sender;
            Response.Redirect("ListView.aspx?opt=" + btn.CommandArgument.ToString() + "&lat=" + userLongitude + "&long=" + userLatitude + "&os=" + userOS, false);
        }

}
}