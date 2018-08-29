using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
    public class MockNationalParkDAL : INationalParkDAL
    {
        public bool AddSurvey(Survey survey)
        {
            throw new NotImplementedException();
        }

        public List<Weather> GetFiveDayWeather(string parkCode)
        {
            throw new NotImplementedException();
        }

        public Park GetPark(string parkCode)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, int> GetParkResults()
        {
            throw new NotImplementedException();
        }

        public List<Park> GetParks()
        {
            throw new NotImplementedException();
        }
    }
}