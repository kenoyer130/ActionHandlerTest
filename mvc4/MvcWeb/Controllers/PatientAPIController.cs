using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using MvcActions.Patients;
using MvcIOC;
using MvcWeb.Controllers.Patients;

namespace MvcWeb.Controllers
{
    public class PatientAPIController : ApiController
    {
        private PatientHelper patientHelper = new PatientHelper();

        // GET /api/values
        public GetPatientCollectionResult Get()
        {
            return patientHelper.GetPatientCollectionResult();
        }

        // GET /api/values/5
        public GetPatientResult Get(int id)
        {
            return patientHelper.GetPatientResult(id);
        }

        // POST /api/values
        public void Post(string value)
        {
        }

        // PUT /api/values/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/values/5
        public void Delete(int id)
        {
        }
    }
}