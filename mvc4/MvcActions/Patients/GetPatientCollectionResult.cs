using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcModel;

namespace MvcActions.Patients
{
    public class GetPatientCollectionResult : IActionResult
    {
        public IEnumerable<Patient> Patients { get; set; }

        public bool HasError {get; set;}
        public string[] Errors { get; set; }
    }
}
