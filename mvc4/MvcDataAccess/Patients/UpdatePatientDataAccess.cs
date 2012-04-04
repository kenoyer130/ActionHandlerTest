using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcModel;
using System.Data.SqlClient;
using Dapper;
using MvcIOC;

namespace MvcDataAccess.Patients
{
    public class UpdatePatientDataAccess
    {
        IConnectionInformation conn;

        public UpdatePatientDataAccess()
        {
            conn = KernelInjection.GetService<IConnectionInformation>();
        }

        public void Execute(Patient patient)
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                dbConnection.Execute(@"UPDATE PATIENT SET FirstName=@FirstName, LastName=@LastName WHERE PatientID=@PatientID;",
                    new { PatientID = patient.PatientID, FirstName = patient.FirstName, LastName = patient.LastName });
            }
        }
    }
}
