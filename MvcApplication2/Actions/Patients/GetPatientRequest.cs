using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Actions.Patients
{
    public class GetPatientRequest : IActionRequest
    {
        public int PatientID { get; set; }
    }
}