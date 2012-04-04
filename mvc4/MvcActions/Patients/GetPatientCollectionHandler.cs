using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDataAccess;
using MvcModel;
using MvcDataAccess.Patients;

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
        IDataAccessRepository dataAccess;

        public GetPatientCollectionHandler(IDataAccessRepository dataAccess)
        {
            this.dataAccess = dataAccess;           
        }

        public GetPatientCollectionResult Execute(GetPatientCollectionRequest request)
        {           
            return new GetPatientCollectionResult
            {
                Patients = dataAccess.Execute<GetPatientCollectionDataAccess,IEnumerable<Patient>>(null)
            };
        }
    }
}