using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Actions.Patients;
using MvcApplication2.IoC;
using Ninject;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    //interesting
    public class HomeController : Controller
    {
        private readonly IPatientDataAccess dataAccess;

        public HomeController(IPatientDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public JsonResult GetPatient(GetPatientRequest request)
        {
            GetPatientHandler handler = new GetPatientHandler(dataAccess,request);           
            return Json(handler.Execute(), JsonRequestBehavior.AllowGet);
        }
    }
}
