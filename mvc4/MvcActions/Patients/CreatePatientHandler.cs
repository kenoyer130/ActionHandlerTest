using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcDataAccess;
using MvcModel;
using MvcDataAccess.Patients;
using MvcWeb.ActionRepository;

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
        IHandlerRepository patientDataAccess;

        public CreatePatientHandler(IHandlerRepository patientDataAccess)
        {
            this.patientDataAccess = patientDataAccess;
        }

        public CreatePatientResult Execute(CreatePatientRequest actionRequest)
        {
            return new CreatePatientResult { PatientID = patientDataAccess.Execute<CreatePatientDataHandler, int>(new {patient = actionRequest.Patient})};
        }
    }
}
