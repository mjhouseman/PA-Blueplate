using System;
using System.Collections;
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
        string option, userOS, lat, lon;
        protected void Page_Load(object sender, EventArgs e)
        {
            option = !string.IsNullOrEmpty(Request.QueryString["opt"]) ? Request.QueryString["opt"] : "none";
            userOS = !string.IsNullOrEmpty(Request.QueryString["os"]) ? Request.QueryString["os"] : "none";
            lat = !string.IsNullOrEmpty(Request.QueryString["lat"]) ? Request.QueryString["lat"] : "0";
            lon = !string.IsNullOrEmpty(Request.QueryString["lon"]) ? Request.QueryString["lon"] : "0";

            string[] populateRepairArray = { "", "BODY REPAIR", "BODY PARTS", "COMPUTER DIAGNOSTICS", "DIESEL LABOR", "EMISSIONS INSPECTIONS", "GLASS PARTS",
                                           "GLASS REPAIR", "LUBE OIL", "MECHANICAL LABOR", "MECHANICAL PARTS", "STATE INSPECTION", "TOWING", "24/7 TOWING"};
            string[] populateTireArray = { "", "MICHELIN", "GOODYEAR", "RETAIL", "COMMERCIAL" };

            switch (option)
            {
                case "Service_Vendors":
                    for (var i = 0; i < populateRepairArray.Length; i++)
                    {
                        var item = new ListItem
                        {
                            Text = populateRepairArray[i].ToString(),
                            Value = i.ToString()
                        };
                        dropdown.Items.Add(item);
                    }
                    PopulatePage("Service");
                    label1.Text = "Repair Stations";
                    break;

                case "Towing_Vendors":
                    dropdown.Enabled = false;
                    dropdown.Visible = false;
                    label1.Text = "Towing Centers";
                    PopulatePage("Towing");
                    ImageButton1.ImageUrl = "img/towtruck.jpg";
                    ImageButton2.ImageUrl = "img/towtruck.jpg";                   
                    ImageButton2.ImageUrl = "img/towtruck.jpg";
                    ImageButton3.ImageUrl = "img/towtruck.jpg";
                    ImageButton4.ImageUrl = "img/towtruck.jpg";
                    ImageButton5.ImageUrl = "img/towtruck.jpg";
                    break;

                case "Tire_Vendors":
                    label1.Text = "Tire Services";
                    for (var i = 0; i < populateTireArray.Length; i++)
                    {
                        var item = new ListItem
                        {
                            Text = populateTireArray[i].ToString(),
                            Value = i.ToString()
                        };
                        dropdown.Items.Add(item);
                    }

                    PopulatePage("Tire");
                    ImageButton1.ImageUrl = "img/tire.png";
                    ImageButton2.ImageUrl = "img/tire.png";
                    ImageButton3.ImageUrl = "img/tire.png";
                    ImageButton4.ImageUrl = "img/tire.png";
                    ImageButton5.ImageUrl = "img/tire.png";
                    break;
            }  
        }

        public void OnListItemClick(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;

            Response.Redirect("Details.aspx?id=" + btn.CommandArgument.ToString() + "&opt=" + option + "&lat=" + lat + "&lon=" + lon + "&os=" + userOS, false);
        }

        public void PopulatePage(string table)
        {
            List<LocationItem> results = new List<LocationItem>();
            try
            {
                string connectionString = "Data Source=localhost;" + "initial catalog=PA_Blueplate_DB;" + "Integrated Security=SSPI;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string sql = "SELECT * FROM " + table + "_NearestCoordinates(@lat, @lon)"; // THIS NEEDS UPDATED TO PASS PARAMETERS FROM DROP DOWN MENU
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@lon",lon);
                        cmd.Parameters.AddWithValue("@lat", lat);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //Save results into LocationItem and store in results array  
                                // Slight bug with Street_Address1 and State.... why??
                                results.Add(new LocationItem(reader["ID"].ToString(), reader["Business_Name"].ToString(), reader["Longitude_Coord"].ToString(), reader["Latitude_Coord"].ToString(), reader["Street_Address1"].ToString(), reader["City"].ToString(), reader["State"].ToString(), reader["Zip_Code"].ToString()));
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

            if (results != null)
            {
                Random rnd = new Random();  //Remove once google distances are in
                for (int i = 0; i < results.Count; i++)
                {

                    //Pass to google and calculate distance

                    //When receive results, store in distance field of object (ie. results[i].distance = "1.0"
                    //For now, test data:

                    double month = rnd.Next(1, 100) / 10.0; //Remove once google distances are in
                    results[i].distance = month.ToString(); //Remove once google distances are in

                }

                List<LocationItem> displayResults = results.OrderBy(o=>o.distance).ToList();

                ImageButton1.CommandArgument = displayResults[0].id.ToString(); //set ID to be passed to details page
                Label11.Text = displayResults[0].businessName.ToString(); //1st name
                Label12.Text = displayResults[0].distance.ToString(); //1st distance
                Label13.Text = displayResults[0].fullAddress.ToString(); //1st address  

                ImageButton2.CommandArgument = displayResults[1].id.ToString();
                Label14.Text = displayResults[1].businessName.ToString();
                Label15.Text = displayResults[1].distance.ToString();
                Label16.Text = displayResults[1].fullAddress.ToString();

                ImageButton3.CommandArgument = displayResults[2].id.ToString();
                Label17.Text = displayResults[2].businessName.ToString();
                Label18.Text = displayResults[2].distance.ToString();
                Label19.Text = displayResults[2].fullAddress.ToString();

                ImageButton4.CommandArgument = displayResults[3].id.ToString();
                Label20.Text = displayResults[3].businessName.ToString();
                Label21.Text = displayResults[3].distance.ToString();
                Label22.Text = displayResults[3].fullAddress.ToString();

                ImageButton5.CommandArgument = displayResults[4].id.ToString();
                Label23.Text = displayResults[4].businessName.ToString();
                Label24.Text = displayResults[4].distance.ToString();
                Label25.Text = displayResults[4].fullAddress.ToString(); 
            }

        }
    }
}