using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.Helpers
{
    public class TempuratureHelper
    {
        public enum EUnits
        {
            c = 1,
            f = 2,
            k = 3
        }

        public static EUnits StringToEunits(string strUnits)
        {
            EUnits tempUnits = new EUnits();
            if (strUnits == "f")
            {
                tempUnits = EUnits.f;
            }
            else if (strUnits == "c")
            {
                tempUnits = EUnits.c;
            }
            else if (strUnits == "k")
            {
                tempUnits = EUnits.k;
            }
            return tempUnits;
        }

        public static string DisplayTempurate(object objUnitType, int TempurateInF)
        {
            string tempString = "";
            EUnits unitType = (EUnits)objUnitType;

            if (unitType == EUnits.f)
            {
                tempString = TempurateInF + "°F";
            }
            else if (unitType == EUnits.c)
            {
                tempString = (int)((TempurateInF - 32) * .5556) + "°C";
            }
            else if (unitType == EUnits.k)
            {
                tempString = (int)((TempurateInF + 459.67) * .5556) + "°K";
            }
            return tempString;
        }

        public static List<string> Advisory(Weather weatherModel)
        {
            List<string> advList = new List<string>();

            if (weatherModel.Forecast == "snow")
            {
                advList.Add("Pack Snow Shoes!");
            } else if(weatherModel.Forecast == "rain")
            {
                advList.Add("Pack Rain Gear!");
            }else if (weatherModel.Forecast == "thunderstorms")
            {
                advList.Add("Seek Shelter, Avoid Hiking on Ridges");
            }
            else if (weatherModel.Forecast == "sunny")
            {
                advList.Add("Pack Sunblock!");
            }

            if(weatherModel.HighTemp > 75)
            {
                advList.Add("Bring Water!");
            }
            else if (weatherModel.LowTemp < 20)
            {
                advList.Add("Pack Sunblock!");
            }else if((weatherModel.HighTemp - weatherModel.LowTemp) > 20)
            {
                advList.Add("Wear Breathable Layers");
            }

            return advList;
        }
    }
}