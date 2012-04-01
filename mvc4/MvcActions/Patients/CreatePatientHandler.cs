using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcDataAccess;
using MvcModel;

namespace MvcActions.Patients
{
    public class CreatePatientRequest : IActionRequest
    {
        public Patient Patient { get; set; }
    }

    public class CreatePatientResult : ActionResult
    {
        public int PatientID { get; set; }
    }

    public class CreatePatientHandler : IActionHandler<CreatePatientRequest, CreatePatientResult>
    {
        IPatientDataAccess patientDataAccess;

        public CreatePatientHandler(IPatientDataAccess patientDataAccess)
        {
            this.patientDataAccess = patientDataAccess;
        }

        public CreatePatientResult Execute(CreatePatientRequest actionRequest)
        {
            return new CreatePatientResult { PatientID = patientDataAccess.CreatePatient(actionRequest.Patient) };
        }
    }
}
