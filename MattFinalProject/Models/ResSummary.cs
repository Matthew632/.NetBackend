using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ResSummary
    {
        public int restaurant_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int rating { get; set; }
        public string photo_url { get; set; }
        public string address { get; set; }
        public string link_to_360 { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public object table_booking { get; set; }
        public object pointer_location { get; set; }
        public DateTime created_at {get; set;}

    }
}
