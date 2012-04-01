using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcActions.Patients;
using MvcIOC;
using MvcIOC.API;
using MvcModel;

namespace MvcWeb.Controllers
{
    public class PatientController : Controller
    {
        private PatientAPI patientAPI;

        public PatientController(PatientAPI patientAPI)
        {
            this.patientAPI = patientAPI;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            return View(patientAPI.GetPatientResult(new GetPatientRequest { PatientID = id }));
        }

        public ActionResult Read(int id)
        {
            return View(patientAPI.GetPatientResult(new GetPatientRequest { PatientID = id }));
        }

        [HttpPost]
        public ActionResult CreateAction(Patient patient)
        {
            int patientID = patientAPI.CreatePatient(new CreatePatientRequest { Patient = patient }).PatientID;
            return RedirectToAction("Read", "Patient", new { patientID });
        }

        public ActionResult UpdateAction(Patient patient)
        {
            patientAPI.UpdatePatient(new UpdatePatientRequest { Patient = patient });
            return RedirectToAction("Read", "Patient", new { ID = patient.PatientID });
        }

        public ActionResult DeleteAction(int id)
        {
            patientAPI.DeletePatient(new DeletePatientRequest { PatientID = id });
            return RedirectToAction("Index", "Patient");
        }
    }
}
