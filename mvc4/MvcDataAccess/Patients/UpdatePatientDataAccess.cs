using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MvcIOC;
using MvcModel;

namespace MvcDataAccess.Patients
{
    public class UpdatePatientDataAccess : IDataHandler 
    {
        readonly IConnectionInformation conn;

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
