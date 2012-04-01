using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using MvcActions.Patients;
using MvcIOC;
using MvcModel;
using MvcWeb.ActionRepository;


namespace MvcWeb.Controllers
{
    public class PatientAPIController : ApiController
    {
        IHandlerRepository handler;

        public PatientAPIController()
        {
            handler = KernelInjection.GetService<IHandlerRepository>();
        }

        // GET /api/values
        public IEnumerable<Patient> Get()
        {
            GetPatientCollectionResult result = handler.Get<GetPatientCollectionHandler,GetPatientCollectionResult>(null);
            return result.Patients.AsEnumerable();
        }

        // GET /api/values/5
        public GetPatientResult Get(int id)
        {
            return handler.Get<GetPatientHandler,GetPatientResult>(new { PatientID = id });
        }

        // POST /api/values
        public CreatePatientResult Create(Patient patient)
        {
            return handler.Get<CreatePatientHandler,CreatePatientResult>(new { Patient = patient });
        }

        // PUT /api/values/5
        public UpdatePatientResult Update(Patient patient)
        {
            return handler.Get<UpdatePatientHandler, UpdatePatientResult>(new { Patient = patient });
        }

        // DELETE /api/values/5
        public DeletePatientResult Delete(int id)
        {
            return handler.Get<DeletePatientHandler, DeletePatientResult>(new { PatientID = id });
        }
    }
}