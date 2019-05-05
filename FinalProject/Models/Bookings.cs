using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Bookings
    {
        public int restaurant_id { get; set; }
        public int table_id { get; set; }
        public int hour_booked { get; set; }
        public string date_booked { get; set; }
        public int user_id { get; set; }
}
}
