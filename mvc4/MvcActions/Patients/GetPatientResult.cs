using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcModel;

namespace MvcActions.Patients
{
    public class GetPatientResult : ActionResult
    {
        public Patient Patient { get; set; }
    }
}