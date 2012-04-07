using System;
using System.Linq;
using System.Web.Mvc;
using MvcActions.Patients;
using MvcIOC;
using MvcModel;

namespace MvcWeb.Controllers
{
    public class PatientController : Controller
    {
        private IHandlerRepository handler;

        public PatientController(IHandlerRepository handler)
        {
            this.handler = handler;
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
            return View(handler.Get<GetPatientHandler, GetPatientResult>(new { PatientID = id }));
        }

        public ActionResult Read(int id)
        {
            return View(handler.Get<GetPatientHandler, GetPatientResult>(new { PatientID = id }));
        }

        public ActionResult CreateAction(Patient patient)
        {
            var newPatient = handler.Get<CreatePatientHandler, CreatePatientResult>(new { Patient = patient });
            return RedirectToAction("Read", "Patient", new { ID = newPatient.PatientID });
        }

        public ActionResult UpdateAction(Patient patient)
        {
            handler.Get<UpdatePatientHandler, UpdatePatientResult>(new { Patient = patient });
            return RedirectToAction("Read", "Patient", new { ID = patient.PatientID });
        }

        public ActionResult DeleteAction(int id)
        {
            handler.Get<DeletePatientHandler, DeletePatientResult>(new { PatientID = id });
            return RedirectToAction("Index", "Patient");
        }
    }
}
