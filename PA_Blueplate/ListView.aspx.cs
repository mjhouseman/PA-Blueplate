using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PA_Blueplate
{
    public partial class ListView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["opt"]))
            {
                label1.Text = Request.QueryString["opt"];
                //ImageButton1.ImageUrl = "img/towtruck.png";

            }
            else
            {
                label1.Text = "NO DATA PROVIDED OR COULD NOT BE READ";
            }

            switch (label1.Text)
            {
                case "Repair Stations":

                    break;
                case "Towing Centers":
                    //ImageButton3.ImageUrl = "img/towtruck.png";
                    //ImageButton4.ImageUrl = "img/towtruck.png";
                    //ImageButton5.ImageUrl = "img/towtruck.png";
                    //ImageButton6.ImageUrl = "img/towtruck.png";
                    //ImageButton7.ImageUrl = "img/towtruck.png";
                    break;
                case "Tire Services":
                    //ImageButton3.ImageUrl= "img/tire.png";
                    //ImageButton4.ImageUrl = "img/tire.png";
                    //ImageButton5.ImageUrl = "img/tire.png";
                    //ImageButton6.ImageUrl = "img/tire.png";
                    //ImageButton7.ImageUrl = "img/tire.png";
                    break;
                default:
                    break;
            }
        }
        //protected void onListItemClick(object sender, EventArgs e)

        public void OnListItemClick(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;

            Response.Redirect("Details.aspx?opt=" + btn.CommandArgument.ToString());
        }

    }
}