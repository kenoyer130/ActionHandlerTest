using System;
namespace MvcApplication2.Models
{
    interface IPatientDataAccess
    {
        Patient GetPatient(int patientID);
    }
}
