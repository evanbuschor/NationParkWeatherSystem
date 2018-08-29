using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
    public interface INationalParkDAL
    {
        List<Park> GetParks();
        Park GetPark(string parkCode);
        List<Weather> GetFiveDayWeather(string parkCode);
        bool AddSurvey(Survey survey);

        /// <summary>
        /// method to return the parks and how many reviews each park has. 
        /// </summary>
        /// <returns>dictionary of park ids and the count of reviews</returns>
        Dictionary<string, int> GetParkResults();
    }
}