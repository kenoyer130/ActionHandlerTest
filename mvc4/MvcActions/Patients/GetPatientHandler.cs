using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDataAccess;
using MvcModel;

namespace MvcActions.Patients
{
    public class GetPatientRequest : IActionRequest
    {
        public int PatientID { get; set; }
    }

    public class GetPatientResult : IActionSingleResult
    {
        public int ID { get; set; }
        public Patient Patient { get; set; }
    }

    public class GetPatientHandler : IActionHandler<GetPatientRequest, GetPatientResult>
    {       
        IPatientDataAccess patientDataAccess;        
       
        public GetPatientHandler(IPatientDataAccess patientDataAccess)
        {           
            this.patientDataAccess = patientDataAccess;           
        }

        public GetPatientResult Execute(GetPatientRequest request)
        {           
            Patient patient = patientDataAccess.GetPatient(request.PatientID);

            return new GetPatientResult
            {
                ID = patient.PatientID,
                Patient = patient
            };
        }
    }
}