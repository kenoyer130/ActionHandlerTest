using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcDataAccess;

namespace MvcActions.Patients
{
    public class DeletePatientRequest : IActionRequest
    {
        public int PatientID { get; set; }
    }

    public class DeletePatientResult : ActionResult
    {

    }

    public class DeletePatientHandler : IActionHandler<DeletePatientRequest, DeletePatientResult>
    {
        IPatientDataAccess patientDataAccess;

        public DeletePatientHandler(IPatientDataAccess patientDataAccess)
        {
            this.patientDataAccess = patientDataAccess;
        }

        public DeletePatientResult Execute(DeletePatientRequest actionRequest)
        {
            patientDataAccess.DeletePatient(actionRequest.PatientID);
            return new DeletePatientResult();
        }
    }
}
