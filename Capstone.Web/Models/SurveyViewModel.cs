using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class SurveyViewModel
    {
        public Survey Survey { get; set; }
        public List<Park> ParkList { get; set; }

    }
}