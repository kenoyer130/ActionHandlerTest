using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcActions.Patients;
using MvcIOC;
using MvcWeb.Controllers.Patients;

namespace MvcWeb.Controllers
{
    public class PatientController : Controller
    {
        private PatientHelper patientHelper = new PatientHelper();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read(int patientID)
        {
            return View(patientHelper.GetPatientResult(patientID));
        }

        public ActionResult Update(int patientID)
        {           
            return View();
        }
    }
}
