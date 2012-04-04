using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcDataAccess;
using MvcDataAccess.Patients;

namespace MvcActions.Patients
{
    public class DeletePatientRequest : IActionRequest
    {
        public int PatientID { get; set; }
    }

    public class DeletePatientResult : IActionResult
    {

    }

    public class DeletePatientHandler : IActionHandler<DeletePatientRequest, DeletePatientResult>
    {
        IDataAccessRepository patientDataAccess;

        public DeletePatientHandler(IDataAccessRepository patientDataAccess)
        {
            this.patientDataAccess = patientDataAccess;
        }

        public DeletePatientResult Execute(DeletePatientRequest actionRequest)
        {
            patientDataAccess.Execute<DeletePatientDataAccess>(new { patientID = actionRequest.PatientID } );
            return new DeletePatientResult();
        }
    }
}
