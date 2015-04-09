using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PA_Blueplate
{
    public partial class ListView : System.Web.UI.Page
    {
        string option, userOS;
        protected void Page_Load(object sender, EventArgs e)
        {
            option = !string.IsNullOrEmpty(Request.QueryString["opt"]) ? Request.QueryString["opt"] : "none";
            userOS = !string.IsNullOrEmpty(Request.QueryString["os"]) ? Request.QueryString["os"] : "none";

            string[] populateRepairArray = { "repair1", "test", "test" };
            string[] populateTireArray = { "tire1", "test", "test" };

            switch (option)
            {
                case "Repair Stations":
                    for (var i = 0; i < populateRepairArray.Length; i++)
                    {
                        var item = new ListItem
                        {
                            Text = populateRepairArray[i].ToString(),
                            Value = i.ToString()
                        };
                        dropdown.Items.Add(item);
                        PopulatePage("Service_Vendors");
                        //Change icons here
                    }
                    break;
                case "Towing Centers":
                    dropdown.Enabled = false;
                    dropdown.Visible = false;
                    PopulatePage("Towing_Vendors");
                    break;
                case "Tire Services":
                    for (var i = 0; i < populateTireArray.Length; i++)
                    {
                        var item = new ListItem
                        {
                            Text = populateTireArray[i].ToString(),
                            Value = i.ToString()
                        };
                        dropdown.Items.Add(item);
                        PopulatePage("Tire_Vendors");
                    }
                    break;
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
            Response.Redirect("Details.aspx");

            //Response.Redirect("Details.aspx?opt=" + btn.CommandArgument.ToString() + "&os=" + userOS, false);
        }

        public void PopulatePage(string table)
        {
            try
            {
                string connectionString = "Data Source=localhost;" + "initial catalog=PA_Blueplate_DB;" + "Integrated Security=SSPI;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM " + table; //Query
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //Save results into a data structure (arraylist?)

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

            //loop through data structure
            //send each to google, update result in data structure
            //end loop
            //sort datastructure
            //use the top 5 to populate corresponding fields - Remember to populate button CommandArguments with unique ID from db

            //error handling!!
        }
    }
}