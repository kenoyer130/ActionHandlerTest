using System;
using MvcModel;
using System.Collections.Generic;
namespace MvcDataAccess
{
    public interface IPatientDataAccess
    {
        Patient GetPatient(int patientID);
        IEnumerable<Patient> GetPatientCollection();
    }
}
