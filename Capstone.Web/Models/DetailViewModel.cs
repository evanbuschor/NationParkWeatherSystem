using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class DetailViewModel
    {
        public Park Park { get; set;}
        public List<Weather> WeatherList { get; set; }
    }
}