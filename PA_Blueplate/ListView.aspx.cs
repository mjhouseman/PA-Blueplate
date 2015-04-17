using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.IO;

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

            string[] populateRepairArray = { "ALL REPAIRS", "BODY REPAIR", "BODY PARTS", "COMPUTER DIAGNOSTICS", "DIESEL LABOR", "EMISSIONS INSPECTIONS", "GLASS PARTS",
                                           "GLASS REPAIR", "LUBE OIL", "MECHANICAL LABOR", "MECHANICAL PARTS", "STATE INSPECTION", "TOWING", "24/7 TOWING"};
            string[] populateTireArray = { "ALL TIRES", "MICHELIN", "GOODYEAR", "RETAIL", "COMMERCIAL" };

            if (option == "Towing_Vendors" || dropdown.Items.Count == 0)
            {
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
                        label1.Text = "Repair Stations";
                        PopulatePage("Service", "");
                        
                        break;

                    case "Towing_Vendors":
                        dropdown.Enabled = false;
                        dropdown.Visible = false;
                        label1.Text = "Towing Centers";
                        PopulatePage("Towing", "");
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

                        PopulatePage("Tire", "");
                        ImageButton1.ImageUrl = "img/tire.png";
                        ImageButton2.ImageUrl = "img/tire.png";
                        ImageButton3.ImageUrl = "img/tire.png";
                        ImageButton4.ImageUrl = "img/tire.png";
                        ImageButton5.ImageUrl = "img/tire.png";
                        break;
                }  
            } 
        }

        public void OnListItemClick(object sender, EventArgs e)
        {
            ImageButton btn = (ImageButton)sender;

            Response.Redirect("Details.aspx?id=" + btn.CommandArgument.ToString() + "&opt=" + option + "&lat=" + lat + "&lon=" + lon + "&os=" + userOS, false);
        }

        public void OnDropDownChange(object sender, EventArgs e)
        {
            switch (dropdown.SelectedItem.Text)
            {
                case "":
                    break;
                case "ALL SERVICES":
                    PopulatePage("Service", "");
                    break;
                case "BODY REPAIR":
                    PopulatePage("Service", " WHERE Body_Repair = 1");
                    break;
                case "BODY PARTS":
                    PopulatePage("Service", " WHERE Body_Parts = 1");
                    break;
                case "COMPUTER DIAGNOSTICS":
                    PopulatePage("Service", " WHERE Computer_Diagnostics = 1");
                    break;
                case "DIESEL LABOR":
                    PopulatePage("Service", " WHERE Diesel_Labor = 1");
                    break;
                case "EMISSIONS INSPECTIONS":
                    PopulatePage("Service", " WHERE Emmissions_Inspections = 1");
                    break;
                case "GLASS PARTS":
                    PopulatePage("Service", " WHERE Glass_Parts = 1");
                    break;
                case "GLASS REPAIR":
                    PopulatePage("Service", " WHERE Glass_Repair = 1");
                    break;
                case "LUBE OIL":
                    PopulatePage("Service", " WHERE Lube_Oil_Change = 1");
                    break;
                case "MECHANICAL LABOR":
                    PopulatePage("Service", " WHERE Mechanical_Labor = 1");
                    break;
                case "MECHANICAL PARTS":
                    PopulatePage("Service", " WHERE Mechanical_Parts = 1");
                    break;
                case "STATE INSPECTION":
                    PopulatePage("Service", " WHERE State_Inspection = 1");
                    break;
                case "TOWING":
                    PopulatePage("Service", " WHERE Towing = 1");
                    break;
                case "24/7 TOWING":
                    PopulatePage("Service", " WHERE Towing_24 = 1");
                    break;
                case "ALL TIRES":
                    PopulatePage("Tire", "");
                    break;
                case "MICHELIN":
                    PopulatePage("Tire", " WHERE Tire_Brand = \'MICHELIN\'");
                    break;
                case "GOODYEAR":
                    PopulatePage("Tire", " WHERE Tire_Brand = \'GOODYEAR\'");
                    break;
                case "RETAIL":
                    PopulatePage("Tire", " WHERE Dealer_Type = \'RETAIL\'");
                    break;
                case "COMMERCIAL":
                    PopulatePage("Tire", " WHERE Dealer_Type = \'COMMERCIAL\'");
                    break;

            }
        }

        public void PopulatePage(string table, string where)
        {
            List<LocationItem> results = new List<LocationItem>();
            try
            {
                string connectionString = "Data Source=localhost;" + "initial catalog=PA_Blueplate_DB;" + "Integrated Security=SSPI;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string sql = "SELECT TOP(10) * FROM " + table + "_NearestCoordinates(@lat, @lon, @rad)" + where; 
                    //string sql = "SELECT TOP(10) * FROM " + "Test_Function(@lat, @lon, @rad)" + where;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@lon",lon);
                        cmd.Parameters.AddWithValue("@lat", lat);
                        cmd.Parameters.AddWithValue("@rad", 1000); // THIS NEEDS UPDATED TO PASS RADIUS WHEN ADDED
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
            string apiUrl;

            if (results != null && results.Count != 0)
            {
              //  Random rnd = new Random();  //Remove once google distances are in
                for (int i = 0; i < results.Count; i++)
                {

                    //Pass to google and calculate distance
                    try
                    {
                        apiUrl = "http://maps.googleapis.com/maps/api/directions/json?origin="+results[i].latitude.ToString()+ ","+ results[i].longitude.ToString()+"&destination="+lat.ToString()+","+lon.ToString()+"&sensor=false";
                        
                        WebRequest request = HttpWebRequest.Create(apiUrl);
                        WebResponse response = request.GetResponse();
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        System.Web.Script.Serialization.JavaScriptSerializer parser = new System.Web.Script.Serialization.JavaScriptSerializer();
                        string responseStringData = reader.ReadToEnd();
                        RootObject responseData = parser.Deserialize<RootObject>(responseStringData);
                        if (responseData != null)
                        {
                            double distance = responseData.routes.Sum(r => r.legs.Sum(l => l.distance.value));
                            if (distance == 0)
                            {
                                throw new Exception("Google cannot find road route");
                            }
                            results[i].distance = distance;

                        }
                        else
                        {
                            throw new Exception("Unable to get location from google");
                        }

                    }
                    finally
                    {



                        
                    }
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

    public class LocationItem
    {
        public string id { get; set; }
        public string objectType { get; set; }
        public string businessName { get; set; }
        public string otherName { get; set; }
        public string fullAddress { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public double distance { get; set; }
        //... continue with remainder of fields from database

        public LocationItem(string id, string businessName, string longitude, string latitude, string stAddress1, string city, string state, string zip)
        {
            this.id = id;
            this.businessName = businessName;
            this.longitude = longitude;
            this.latitude = latitude;
            this.fullAddress = (!string.IsNullOrEmpty(stAddress1) ? stAddress1 : "") + ", " +
                               (!string.IsNullOrEmpty(city) ? city : "") + ", " +
                               (!string.IsNullOrEmpty(state) ? state : "") + " " +
                               (!string.IsNullOrEmpty(zip) ? zip : "");
        }
    }
    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class StartLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Distance2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class EndLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Polyline
    {
        public string points { get; set; }
    }

    public class StartLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Step
    {
        public Distance2 distance { get; set; }
        public Duration2 duration { get; set; }
        public EndLocation2 end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public StartLocation2 start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }

    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public EndLocation end_location { get; set; }
        public string start_address { get; set; }
        public StartLocation start_location { get; set; }
        public List<Step> steps { get; set; }
        public List<object> via_waypoint { get; set; }
    }

    public class OverviewPolyline
    {
        public string points { get; set; }
    }

    public class Route
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public List<Leg> legs { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
        public string summary { get; set; }
        public List<object> warnings { get; set; }
        public List<object> waypoint_order { get; set; }
    }

    public class RootObject
    {
        public List<Route> routes { get; set; }
        public string status { get; set; }
    }  
}