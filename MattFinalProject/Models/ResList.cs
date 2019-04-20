using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ResList
    {
        public List<ResSummary> resList { get; set; }
        public ResList()
        {
            resList = new List<ResSummary>();
        }
    }
}
