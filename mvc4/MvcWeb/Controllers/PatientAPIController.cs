using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using MvcActions.Patients;
using MvcIOC;
using MvcAPI;
using MvcModel;


namespace MvcWeb.Controllers
{
    public class PatientAPIController : ApiController
    {
        IPatientAPI patientAPI;

        public PatientAPIController()
        {
            patientAPI = KernelInjection.GetService<IPatientAPI>();
        }

        // GET /api/values
        public IEnumerable<Patient> Get()
        {
            GetPatientCollectionResult result = patientAPI.GetPatientCollectionResult(new GetPatientCollectionRequest());
            return result.Patients.AsEnumerable();
        }

        // GET /api/values/5
        public GetPatientResult Get(int id)
        {
            return patientAPI.GetPatientResult(new GetPatientRequest {  PatientID = id });
        }

        // POST /api/values
        public CreatePatientResult Create(Patient patient)
        {
            return patientAPI.CreatePatient(new CreatePatientRequest { Patient = patient });
        }

        // PUT /api/values/5
        public UpdatePatientResult Update(Patient patient)
        {
            return patientAPI.UpdatePatient(new UpdatePatientRequest { Patient = patient });
        }

        // DELETE /api/values/5
        public DeletePatientResult Delete(int id)
        {
            return patientAPI.DeletePatient(new DeletePatientRequest { PatientID = id });
        }
    }
}