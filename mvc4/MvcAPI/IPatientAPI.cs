using System;
using MvcActions.Patients;
using MvcModel;

namespace MvcAPI
{
    public interface IPatientAPI
    {
        GetPatientCollectionResult GetPatientCollectionResult(GetPatientCollectionRequest request);
        GetPatientResult GetPatientResult(GetPatientRequest request);
        CreatePatientResult CreatePatient(CreatePatientRequest request);
        UpdatePatientResult UpdatePatient(UpdatePatientRequest request);      
        DeletePatientResult DeletePatient(DeletePatientRequest request);
    }
}
