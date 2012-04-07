﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcDataAccess;
using MvcModel;
using MvcDataAccess.Patients;
using MvcWeb.ActionRepository;

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
        IHandlerRepository patientDataAccess;

        public UpdatePatientHandler(IHandlerRepository patientDataAccess)
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

