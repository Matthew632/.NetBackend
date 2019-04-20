using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ResList
    {
        public List<ResSummary> restaurants { get; set; }
        public ResList()
        {
            restaurants = new List<ResSummary>();
        }
    }
}
