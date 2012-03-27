using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Actions.Patients;
using MvcApplication2.Models;

namespace MvcApplication2.Actions.Patients
{
    //interesting
    public class GetPatientHandler : IActionHandler
    {
        GetPatientRequest request;
        IPatientDataAccess patientDataAccess;

        // PatientDataAccess would actually use injection
        public GetPatientHandler(GetPatientRequest request, PatientDataAccess patientDataAccess)
        {
            this.request = request;
            this.patientDataAccess = patientDataAccess;
        }

        public IActionResult Execute()
        {           
            return new GetPatientResult
            {
                Patient = patientDataAccess.GetPatient(request.PatientID)
            };
        }
    }
}