using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDataAccess;

namespace MvcActions.Patients
{   
    public class GetPatientHandler : IActionHandler<GetPatientRequest, GetPatientResult>
    {       
        IPatientDataAccess patientDataAccess;        
       
        public GetPatientHandler(IPatientDataAccess patientDataAccess)
        {           
            this.patientDataAccess = patientDataAccess;           
        }

        public GetPatientResult Execute(GetPatientRequest request)
        {           
            return new GetPatientResult
            {
                Patient = patientDataAccess.GetPatient(request.PatientID)
            };
        }
    }
}