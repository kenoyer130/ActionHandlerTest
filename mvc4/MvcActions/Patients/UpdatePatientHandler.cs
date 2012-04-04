using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcDataAccess;
using MvcModel;
using MvcDataAccess.Patients;

namespace MvcActions.Patients
{
    public class UpdatePatientRequest : IActionRequest
    {
        public Patient Patient { get; set; }
    }

    public class UpdatePatientResult : IActionResult
    {
        public Patient Patient { get; set; }
    }

    public class UpdatePatientHandler : IActionHandler<UpdatePatientRequest, UpdatePatientResult>
    {
        IDataAccessRepository patientDataAccess;

        public UpdatePatientHandler(IDataAccessRepository patientDataAccess)
        {
            this.patientDataAccess = patientDataAccess;
        }

        public UpdatePatientResult Execute(UpdatePatientRequest actionRequest)
        {
            patientDataAccess.Execute<UpdatePatientDataAccess, Patient>(new { patient = actionRequest.Patient });

            return new UpdatePatientResult();
        }
    }
}

