using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DALs;
using Capstone.Web.Models;
using Capstone.Web.Helpers;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        INationalParkDAL _dal;
        public HomeController(INationalParkDAL dal)
        {
            this._dal = dal;
        }

        // GET: Home
        public ActionResult Index()
        {
            Session["currentPage"] = "home";

            //if your units are net set defualt them to f
            if (Session["units"] == null)
            {
                Session["units"] = TempuratureHelper.EUnits.f;
            }

            List<Park> parks = new List<Park>();

            parks = _dal.GetParks();

            return View("Index",parks);
        }

        public ActionResult ChangeUnits(string units)
        {
            TempuratureHelper.EUnits tempUnits = TempuratureHelper.StringToEunits(units);
            
            Session["units"] = tempUnits;
            return Redirect(Request.UrlReferrer.ToString());
        }


    }
}