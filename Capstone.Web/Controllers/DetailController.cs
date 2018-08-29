using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DALs;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class DetailController : Controller
    {

        INationalParkDAL _dal;
        public DetailController(INationalParkDAL dal)
        {
            this._dal = dal;
        }

        // GET: Detail
        public ActionResult Index(string parkCode)
        {   
            Session["currentPage"] = "detail";

            Park park = new Park();
            List<Weather> weatherList = new List<Weather>();
            DetailViewModel detailViewModel = new DetailViewModel();

            park = _dal.GetPark(parkCode);
            weatherList = _dal.GetFiveDayWeather(parkCode);
            detailViewModel.Park = park;
            detailViewModel.WeatherList = weatherList;

            return View("Details", detailViewModel);
        }
    }
}