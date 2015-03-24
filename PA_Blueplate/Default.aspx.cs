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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void MyBtnHandler(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            Response.Redirect("ListView.aspx?opt=" + btn.CommandArgument.ToString());
        }
}
}