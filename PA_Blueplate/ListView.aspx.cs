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
using System.Device.Location;
using PA_Blueplate.GeocodeService;
using PA_Blueplate.SearchService;
using PA_Blueplate.ImageryService;
using PA_Blueplate.RouteService;
using System.Xml;

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

            hdnTable.Value = "";
            hdnWhere.Value = "";
            hdnRadius.Value = "1000";

            if (!IsPostBack) 
            {
                if (lat.Equals("lat"))
                {
                    TxtManualLocation.Text = "GPS UNAVAILABLE";
                    hdnLat.Value = "";
                    hdnLon.Value = "";
                }
                else
                {
                    TxtManualLocation.Text = "CURRENT LOCATION";
                    hdnLat.Value = lat;
                    hdnLon.Value = lon;
                }
            } 

            string[] populateRepairArray = { "ALL REPAIRS", "BODY REPAIR", "BODY PARTS", "COMPUTER DIAGNOSTICS", "DIESEL LABOR", "EMISSIONS INSPECTIONS", "GLASS PARTS",
                                           "GLASS REPAIR", "LUBE OIL", "MECHANICAL LABOR", "MECHANICAL PARTS", "STATE INSPECTION", "TOWING", "24/7 TOWING"};
            string[] populateTireArray = { "ALL TIRES", "MICHELIN", "GOODYEAR", "RETAIL", "COMMERCIAL" };
            string[] radiusArray = { "NO LIMIT", "10 MILES", "25 MILES", "50 MILES", "75 MILES", "100 MILES" };

            if (RadiusDropDown.Items.Count == 0)
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
                        for (var i = 0; i < radiusArray.Length; i++)
                        {
                            var item = new ListItem
                            {
                                Text = radiusArray[i].ToString(),
                                Value = i.ToString()
                            };
                            RadiusDropDown.Items.Add(item);
                        }

                        label1.Text = "Repair Stations";
                        hdnTable.Value = "Service";
                        PopulatePage();
                        
                        break;

                    case "Towing_Vendors":
                        for (var i = 0; i < radiusArray.Length; i++)
                        {
                            var item = new ListItem
                            {
                                Text = radiusArray[i].ToString(),
                                Value = i.ToString()
                            };
                            RadiusDropDown.Items.Add(item);
                        }
                        dropdown.Enabled = false;
                        dropdown.Visible = false;
                        label1.Text = "Towing Centers";
                        hdnTable.Value = "Towing";
                        PopulatePage();
                        ImageButton1.ImageUrl = "img/towing.png";
                        ImageButton2.ImageUrl = "img/towing.png";
                        ImageButton2.ImageUrl = "img/towing.png";
                        ImageButton3.ImageUrl = "img/towing.png";
                        ImageButton4.ImageUrl = "img/towing.png";
                        ImageButton5.ImageUrl = "img/towing.png";
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
                        for (var i = 0; i < radiusArray.Length; i++)
                        {
                            var item = new ListItem
                            {
                                Text = radiusArray[i].ToString(),
                                Value = i.ToString()
                            };
                            RadiusDropDown.Items.Add(item);
                        }
                        hdnTable.Value = "Tire";
                        PopulatePage();
                        ImageButton1.ImageUrl = "img/tire1.png";
                        ImageButton2.ImageUrl = "img/tire1.png";
                        ImageButton3.ImageUrl = "img/tire1.png";
                        ImageButton4.ImageUrl = "img/tire1.png";
                        ImageButton5.ImageUrl = "img/tire1.png";
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
                    //PopulatePage("Service", "");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = "";
                    break;
                case "BODY REPAIR":
                    //PopulatePage("Service", " WHERE Body_Repair = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Body_Repair = 1";
                    break;
                case "BODY PARTS":
                    //PopulatePage("Service", " WHERE Body_Parts = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Body_Parts = 1";
                    break;
                case "COMPUTER DIAGNOSTICS":
                    //PopulatePage("Service", " WHERE Computer_Diagnostics = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Computer_Diagnostics = 1";
                    break;
                case "DIESEL LABOR":
                    //PopulatePage("Service", " WHERE Diesel_Labor = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Diesel_Labor = 1";
                    break;
                case "EMISSIONS INSPECTIONS":
                    //PopulatePage("Service", " WHERE Emmissions_Inspections = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Emmissions_Inspections = 1";
                    break;
                case "GLASS PARTS":
                    //PopulatePage("Service", " WHERE Glass_Parts = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Glass_Parts = 1";
                    break;
                case "GLASS REPAIR":
                    //PopulatePage("Service", " WHERE Glass_Repair = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Glass_Repair = 1";
                    break;
                case "LUBE OIL":
                    //PopulatePage("Service", " WHERE Lube_Oil_Change = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Lube_Oil_Change = 1";
                    break;
                case "MECHANICAL LABOR":
                    //PopulatePage("Service", " WHERE Mechanical_Labor = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Mechanical_Labor = 1";
                    break;
                case "MECHANICAL PARTS":
                    //PopulatePage("Service", " WHERE Mechanical_Parts = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Mechanical_Parts = 1";
                    break;
                case "STATE INSPECTION":
                    //PopulatePage("Service", " WHERE State_Inspection = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE State_Inspection = 1";
                    break;
                case "TOWING":
                    //PopulatePage("Service", " WHERE Towing = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Towing = 1";
                    break;
                case "24/7 TOWING":
                    //PopulatePage("Service", " WHERE Towing_24 = 1");
                    hdnTable.Value = "Service";
                    hdnWhere.Value = " WHERE Towing_24 = 1";
                    break;
                case "ALL TIRES":
                    //PopulatePage("Tire", "");
                    hdnTable.Value = "Tire";
                    hdnWhere.Value = "";
                    break;
                case "MICHELIN":
                    //PopulatePage("Tire", " WHERE Tire_Brand = \'MICHELIN\'");
                    hdnTable.Value = "Tire";
                    hdnWhere.Value = " WHERE Tire_Brand = \'MICHELIN\'";
                    break;
                case "GOODYEAR":
                    //PopulatePage("Tire", " WHERE Tire_Brand = \'GOODYEAR\'");
                    hdnTable.Value = "Tire";
                    hdnWhere.Value = " WHERE Tire_Brand = \'GOODYEAR\'";
                    break;
                case "RETAIL":
                    //PopulatePage("Tire", " WHERE Dealer_Type = \'RETAIL\'");
                    hdnTable.Value = "Tire";
                    hdnWhere.Value = " WHERE Dealer_Type = \'RETAIL\'";
                    break;
                case "COMMERCIAL":
                    //PopulatePage("Tire", " WHERE Dealer_Type = \'COMMERCIAL\'");
                    hdnTable.Value = "Tire";
                    hdnWhere.Value = " WHERE Dealer_Type = \'COMMERCIAL\'";
                    break;
                //Response.Redirect(Request.RawUrl);
            }
            PopulatePage();
        }

        public void PopulatePage()
        {
            string table = hdnTable.Value;
            string where = hdnWhere.Value;
            string radius = hdnRadius.Value;
            string latitude = hdnLat.Value;  
            string longitude = hdnLon.Value;

            if (TxtManualLocation.Text == "NO RESULTS FOUND" || TxtManualLocation.Text == "GPS UNAVAILABLE")  // ADDED!
            {
                TxtManualLocation.Text = (lat != "lat") ? "CURRENT LOCATION" : "GPS UNAVAILABLE";
            }

            List<LocationItem> results = new List<LocationItem>();
            try
            {
                //string connectionString = "Data Source=localhost;" + "initial catalog=PA_Blueplate_DB;" + "Integrated Security=SSPI;";
                string connectionString = "Data Source=CMPSC488-SERVER.CS.HBG.PSU.EDU;Initial Catalog=PA_Blueplate_DB;User Id=MasterUser;Password=Blueplate$$20;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string sql = "SELECT TOP(10) * FROM " + table + "_NearestCoordinates(@lat, @lon, @rad)" + where + " ORDER BY Distance"; 
                    //string sql = "SELECT TOP(10) * FROM " + "Test_Function(@lat, @lon, @rad)" + where;
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@lon",longitude);
                        cmd.Parameters.AddWithValue("@lat", latitude);
                        cmd.Parameters.AddWithValue("@rad", radius);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //Save results into LocationItem and store in results array  
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
                    string destination= results[i].latitude.ToString() + "," + results[i].longitude.ToString();
                    string origin = hdnLat.Value.ToString() + "," + hdnLon.Value.ToString();
                    string url = @"http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" + origin + "&destinations=" + destination + "&mode=driving&sensor=false&language=en-EN&units=imperial";

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader sreader = new StreamReader(dataStream);
                    string responsereader = sreader.ReadToEnd();
                    response.Close();

                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(responsereader);


                    if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
                    {
                        XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                        results[i].distance = Convert.ToDouble(distance[0].ChildNodes[1].InnerText.Replace(" mi", ""));
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
                Console.WriteLine(hdnRadius.Value);

                if(displayResults[0].distance > Convert.ToDouble(hdnRadius.Value))
                {
                    ImageButton1.Visible = false;
                    Label11.Visible = false;
                    Label12.Visible = false;
                    Label13.Visible = false;
                }
                if (displayResults[1].distance > Convert.ToDouble(hdnRadius.Value))
                {
                    ImageButton2.Visible = false;
                    Label14.Visible = false;
                    Label15.Visible = false;
                    Label16.Visible = false;
                }
                if (displayResults[2].distance > Convert.ToDouble(hdnRadius.Value))
                {
                    ImageButton3.Visible = false;
                    Label17.Visible = false;
                    Label18.Visible = false;
                    Label19.Visible = false;
                }
                if (displayResults[3].distance > Convert.ToDouble(hdnRadius.Value))
                {
                    ImageButton4.Visible = false;
                    Label20.Visible = false;
                    Label21.Visible = false;
                    Label22.Visible = false;
                }
                if (displayResults[4].distance > Convert.ToDouble(hdnRadius.Value))
                {
                    ImageButton5.Visible = false;
                    Label23.Visible = false;
                    Label24.Visible = false;
                    Label25.Visible = false;
                }

            }
            
        }

        protected void OnCurrentLocationClick(object sender, EventArgs e)
        {
            if (lat.Equals("lat"))
            {
                TxtManualLocation.Text = "GPS UNAVAILABLE";
            }
            else
            {
                TxtManualLocation.Text = "CURRENT LOCATION";
                hdnLat.Value = lat;  
                hdnLon.Value = lon;
                PopulatePage();
            }
        }

        protected void OnManualLocationClick(object sender, EventArgs e)
        {
            TxtManualLocation.Text = GeocodeAddress(TxtManualLocation.Text);
            PopulatePage();
        }

        protected void OnRadiusDropDownChange(object sender, EventArgs e)
        {
            switch (RadiusDropDown.SelectedItem.Text)
            {
                case "NO LIMIT":
                    hdnRadius.Value = "1000";
                    break;
                case "10 MILES":
                    hdnRadius.Value = "10";
                    break;
                case "25 MILES":
                    hdnRadius.Value = "25";
                    break;
                case "50 MILES":
                    hdnRadius.Value = "50";
                    break;
                case "75 MILES":
                    hdnRadius.Value = "75";
                    break;
                case "100 MILES":
                    hdnRadius.Value = "100";
                    break;
            }
            PopulatePage();
        }

        public String GeocodeAddress(string address)
        {
            string results = "";
            string key = "An7hQ9l8lVG2L68n1gzeHvWNqWlUoiGc-oxExfjCSTJhIFU4WPAIAjMXf3g03dcv";
            GeocodeRequest geocodeRequest = new GeocodeRequest();

            // Set the credentials using a valid Bing Maps key
            geocodeRequest.Credentials = new GeocodeService.Credentials();
            geocodeRequest.Credentials.ApplicationId = key;

            // Set the full address query
            geocodeRequest.Query = address;

            // Set the options to only return high confidence results 
            ConfidenceFilter[] filters = new ConfidenceFilter[1];
            filters[0] = new ConfidenceFilter();
            filters[0].MinimumConfidence = GeocodeService.Confidence.High;

            // Add the filters to the options
            GeocodeOptions geocodeOptions = new GeocodeOptions();
            geocodeOptions.Filters = filters;
            geocodeRequest.Options = geocodeOptions;

            // Make the geocode request
            GeocodeServiceClient geocodeService = new GeocodeServiceClient("BasicHttpBinding_IGeocodeService");
            GeocodeResponse geocodeResponse = geocodeService.Geocode(geocodeRequest);

            if (geocodeResponse.Results.Length > 0)
            {
                results = String.Format("{0}, {1}",
                  geocodeResponse.Results[0].Locations[0].Latitude,
                  geocodeResponse.Results[0].Locations[0].Longitude);
                hdnLat.Value = geocodeResponse.Results[0].Locations[0].Latitude.ToString();
                hdnLon.Value = geocodeResponse.Results[0].Locations[0].Longitude.ToString();
            }
            else
                results = "NO RESULTS FOUND";

            return results;
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
