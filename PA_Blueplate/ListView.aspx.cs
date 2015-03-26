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
                    ImageButton1.ImageUrl = "img/towtruck.jpg";
                    ImageButton2.ImageUrl = "img/towtruck.jpg";                   
                    ImageButton2.ImageUrl = "img/towtruck.jpg";
                    ImageButton3.ImageUrl = "img/towtruck.jpg";
                    ImageButton4.ImageUrl = "img/towtruck.jpg";
                    ImageButton5.ImageUrl = "img/towtruck.jpg";
                    break;
                case "Tire Services":
                    ImageButton1.ImageUrl = "img/tire.png";
                    ImageButton2.ImageUrl = "img/tire.png";
                    ImageButton3.ImageUrl = "img/tire.png";
                    ImageButton4.ImageUrl = "img/tire.png";
                    ImageButton5.ImageUrl = "img/tire.png";
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