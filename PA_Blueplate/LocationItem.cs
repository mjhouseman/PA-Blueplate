using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PA_Blueplate
{
    public class LocationItem
    {
        public string id { get; set; }
        public string objectType { get; set; }
        public string businessName { get; set; }
        public string otherName { get; set; }
        public string fullAddress { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string distance { get; set; }
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
}