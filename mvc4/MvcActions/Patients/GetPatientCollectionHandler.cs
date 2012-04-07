using System;
using System.Collections.Generic;
using System.Linq;
using MvcDataAccess.Patients;
using MvcIOC;
using MvcModel;

namespace MvcActions.Patients
{
    public class GetPatientCollectionRequest : IActionRequest
    {
    }

    public class GetPatientCollectionResult : IActionResult
    {
        public IEnumerable<Patient> Patients { get; set; }
    }

    public class GetPatientCollectionHandler : IActionHandler<GetPatientCollectionRequest, GetPatientCollectionResult>
    {
        IHandlerRepository dataAccess;

        public GetPatientCollectionHandler(IHandlerRepository dataAccess)
        {
            this.dataAccess = dataAccess;           
        }

        public GetPatientCollectionResult Execute(GetPatientCollectionRequest request)
        { 
            return new GetPatientCollectionResult
            {
                Patients = dataAccess.Execute<GetPatientCollectionDataAccess, IEnumerable<Patient>>(null)
            };
        }
    }
}