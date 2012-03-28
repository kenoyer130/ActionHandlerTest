using System;
namespace MvcApplication2.Models
{
    public interface IPatientDataAccess
    {
        Patient GetPatient(int patientID);
    }
}
