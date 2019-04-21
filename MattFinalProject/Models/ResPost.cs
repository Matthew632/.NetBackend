using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ResPost
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Photo_url { get; set; }
        public string Address { get; set; }
        public string Link_to_360 { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public JObject TableBooking { get; set; }
    }
}
