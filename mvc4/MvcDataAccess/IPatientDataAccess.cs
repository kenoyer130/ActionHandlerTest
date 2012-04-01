using System;
using MvcModel;
using System.Collections.Generic;
namespace MvcDataAccess
{
    public interface IPatientDataAccess
    {
        int CreatePatient(Patient patient);
        Patient GetPatient(int patientID);
        IEnumerable<Patient> GetPatientCollection();
        void DeletePatient(int patientID);
        void UpdatePatient(Patient patient);
    }
}
