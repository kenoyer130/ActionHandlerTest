using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class PatientDataAccess : IPatientDataAccess
    {
        public Patient GetPatient(int patientID)
        {
            return new Patient
            {
                FirstName = "first",
                LastName = "last"
            };
        }
    }
}