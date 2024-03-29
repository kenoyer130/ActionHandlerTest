﻿using System;
using System.Linq;
using MvcDataAccess.Patients;
using MvcIOC;

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
        IHandlerRepository patientDataAccess;

        public DeletePatientHandler(IHandlerRepository patientDataAccess)
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
