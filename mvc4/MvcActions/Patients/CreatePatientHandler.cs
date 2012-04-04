using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcDataAccess;
using MvcModel;
using MvcDataAccess.Patients;

namespace MvcActions.Patients
{
    public class CreatePatientRequest : IActionRequest
    {
        public Patient Patient { get; set; }
    }

    public class CreatePatientResult : IActionResult
    {
        public int PatientID { get; set; }
    }

    public class CreatePatientHandler : IActionHandler<CreatePatientRequest, CreatePatientResult>
    {
        IDataAccessRepository patientDataAccess;

        public CreatePatientHandler(IDataAccessRepository patientDataAccess)
        {
            this.patientDataAccess = patientDataAccess;
        }

        public CreatePatientResult Execute(CreatePatientRequest actionRequest)
        {
            return new CreatePatientResult { PatientID = patientDataAccess.Execute<CreatePatientDataAccess, int>(new {patient = actionRequest.Patient})};
        }
    }
}
