using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;

namespace MvcApplication2.Actions.Patients
{
    public class GetPatientResult : ActionResult
    {
        public Patient Patient { get; set; }
    }
}