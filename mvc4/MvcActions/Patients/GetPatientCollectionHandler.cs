using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDataAccess;
using MvcModel;

namespace MvcActions.Patients
{
    public class GetPatientCollectionRequest : IActionRequest
    {
    }

    public class GetPatientCollectionResult : ActionResult
    {
        public IEnumerable<Patient> Patients { get; set; }
    }

    public class GetPatientCollectionHandler : IActionHandler<GetPatientCollectionRequest, GetPatientCollectionResult>
    {       
        IPatientDataAccess patientDataAccess;        
       
        public GetPatientCollectionHandler(IPatientDataAccess patientDataAccess)
        {           
            this.patientDataAccess = patientDataAccess;           
        }

        public GetPatientCollectionResult Execute(GetPatientCollectionRequest request)
        {           
            return new GetPatientCollectionResult
            {
                Patients = patientDataAccess.GetPatientCollection()
            };
        }
    }
}