using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class BookingPost
    {
        public int restaurant_id { get; set; }
        public int table_id { get; set; }
        public float x_axis { get; set; }
        public float y_axis { get; set; }
        public float z_axis { get; set; }
        public int hour_booked { get; set; }
        public string date_booked { get; set; }
        public int user_id { get; set; }
}
}
