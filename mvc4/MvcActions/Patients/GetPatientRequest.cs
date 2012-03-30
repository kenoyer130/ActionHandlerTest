using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcActions.Patients
{
    public class GetPatientRequest : IActionRequest
    {
        public int PatientID { get; set; }
    }
}