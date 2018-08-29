using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DALs;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        SurveyViewModel _surveryViewModel = new SurveyViewModel();

        INationalParkDAL _dal;
        public SurveyController(INationalParkDAL dal)
        {
            this._dal = dal;
        }

        // GET: Survey
        public ActionResult Index()
        {
            
            _surveryViewModel.ParkList = _dal.GetParks();
            
            Session["currentPage"] = "survey";
            return View("Survey", _surveryViewModel);
        }

        [HttpPost]
        public ActionResult SubmitForm(SurveyViewModel model)
        {
            ActionResult result;

            if (!ModelState.IsValid)
            {
                _surveryViewModel.ParkList = _dal.GetParks();
                result = View("Survey", _surveryViewModel);
            }
            else
            {
                _dal.AddSurvey(model.Survey);
                result = RedirectToAction("Index", "FavoriteParks");
            }
            return result;
        }
    }
}