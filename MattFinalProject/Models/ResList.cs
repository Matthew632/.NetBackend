using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MattFinalProject.Models
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
