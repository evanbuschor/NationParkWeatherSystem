using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DALs;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class FavoriteParksController : Controller
    {

        INationalParkDAL _dal;
        public FavoriteParksController(INationalParkDAL dal)
        {
            this._dal = dal;
        }

        // GET: FavoriteParks
        public ActionResult Index()
        {
            var favParks = _dal.GetParkResults();
            Session["currentPage"] = "favorites";

            return View("FavoriteParks", favParks);
        }
    }
}