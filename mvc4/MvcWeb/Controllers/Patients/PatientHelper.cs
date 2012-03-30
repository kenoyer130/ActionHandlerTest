using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcIOC;
using MvcActions.Patients;

namespace MvcWeb.Controllers.Patients
{
    public class PatientHelper
    {
        public GetPatientCollectionResult GetPatientCollectionResult()
        {
            GetPatientCollectionHandler handler = KernelInjection.GetService<GetPatientCollectionHandler>();
            return handler.Execute(null);
        }

        public GetPatientResult GetPatientResult(int patientID)
        {
            GetPatientRequest request = new GetPatientRequest();
            request.PatientID = patientID;

            GetPatientHandler handler = KernelInjection.GetService<GetPatientHandler>();

            return handler.Execute(request);
        }      
    }
}