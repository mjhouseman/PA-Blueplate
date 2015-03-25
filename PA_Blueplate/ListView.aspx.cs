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
        }
        //protected void onListItemClick(object sender, EventArgs e)

        public void OnListItemClick(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;

            Response.Redirect("Details.aspx?opt=" + btn.CommandArgument.ToString());
        }

    }
}