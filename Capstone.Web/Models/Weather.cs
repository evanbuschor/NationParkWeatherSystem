using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForcastValue { get; set; }
        public int LowTemp { get; set; }
        public int HighTemp { get; set; }
        public string Forecast { get; set; }

        public static List<SelectListItem> TempTypes { get; } = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Farenheit"},
            new SelectListItem() {Text = "Celcius"},
        };

        public static implicit operator List<object>(Weather v)
        {
            throw new NotImplementedException();
        }
    }
}
