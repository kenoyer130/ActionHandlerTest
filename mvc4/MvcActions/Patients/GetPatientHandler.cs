using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDataAccess;
using MvcModel;
using MvcDataAccess.Patients;
using MvcWeb.ActionRepository;

namespace MvcActions.Patients
{
    public class GetPatientRequest : IActionRequest
    {
        public int PatientID { get; set; }
        public GetPatientRequest() { }
    }

    public class GetPatientResult : IActionSingleResult
    {
        public int ID { get; set; }
        public Patient Patient { get; set; }
    }

    public class GetPatientHandler : IActionHandler<GetPatientRequest, GetPatientResult>
    {
        IHandlerRepository dataAccess;

        public GetPatientHandler(IHandlerRepository dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public GetPatientResult Execute(GetPatientRequest request)
        {
            Patient patient = dataAccess.Execute<GetPatientDataAccess, Patient>(new { patientID = request.PatientID });

            return new GetPatientResult
            {
                ID = patient.PatientID,
                Patient = patient
            };
        }
    }
}