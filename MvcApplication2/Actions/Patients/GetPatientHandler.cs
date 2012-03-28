using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Actions.Patients;
using MvcApplication2.Models;
using Ninject;

namespace MvcApplication2.Actions.Patients
{   
    public class GetPatientHandler : IActionHandler
    {       
        IPatientDataAccess patientDataAccess;
        GetPatientRequest request { get; set; }
       
        public GetPatientHandler(IPatientDataAccess patientDataAccess, GetPatientRequest request)
        {           
            this.patientDataAccess = patientDataAccess;
            this.request = request;
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