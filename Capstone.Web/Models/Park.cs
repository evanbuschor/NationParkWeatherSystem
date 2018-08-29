using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Park
    {
        public string Code {get; set;}
        public string Name { get; set; }
        public string State { get; set; }
        public int Size { get; set; }
        public int Elevation { get; set; }
        public double MilesOfTrails { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitors { get; set; }
        public string Quote { get; set; }
        public string QuoteSource { get; set; }
        public string Description { get; set; }
        public int EntryFee { get; set; }
        public int Species { get; set; }
    }
}