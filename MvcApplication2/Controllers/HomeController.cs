using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Actions.Patients;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
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
            return Json(new GetPatientHandler(request).Execute(), JsonRequestBehavior.AllowGet);
        }
    }
}
