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
        String option;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["opt"]))
            {
                option = Request.QueryString["opt"];
            }
            else
            {
                option = "none";
            }

            switch (option)
            {
                case "repairs" :
                    
                    break;
                case "towing" :
                    lblPhone.Visible = false;
                    lblPhoneText.Visible = false;
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
    }
}