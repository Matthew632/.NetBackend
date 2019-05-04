using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class LocList
    {
        public List<Locations> locations { get; set; }
        public LocList()
        {
            locations = new List<Locations>();
        }
    }
}
