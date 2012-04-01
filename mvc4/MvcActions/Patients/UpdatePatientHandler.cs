using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcDataAccess;
using MvcModel;

namespace MvcActions.Patients
{
    public class UpdatePatientRequest : IActionRequest
    {
        public Patient Patient { get; set; }
    }

    public class UpdatePatientResult : ActionResult
    {
        public Patient Patient { get; set; }
    }

    public class UpdatePatientHandler : IActionHandler<UpdatePatientRequest, UpdatePatientResult>
    {
        IPatientDataAccess patientDataAccess;

        public UpdatePatientHandler(IPatientDataAccess patientDataAccess)
        {
            this.patientDataAccess = patientDataAccess;
        }

        public UpdatePatientResult Execute(UpdatePatientRequest actionRequest)
        {
            patientDataAccess.UpdatePatient(actionRequest.Patient);

            return new UpdatePatientResult();
        }
    }
}

