using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class BookingsList
    {
        public List<Bookings> bookings { get; set; }
        public BookingsList()
        {
            bookings = new List<Bookings>();
        }
    }
}
