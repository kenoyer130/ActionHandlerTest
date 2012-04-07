using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MvcIOC;
using MvcModel;

namespace MvcDataAccess.Patients
{
    public class GetPatientDataAccess : IDataHandler 
    {
        readonly IConnectionInformation conn;

        public GetPatientDataAccess()
        {
            conn = KernelInjection.GetService<IConnectionInformation>();
        }

        public Patient Execute(int patientID)
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                return dbConnection.Query<Patient>(@"SELECT 
                                                        PatientID, 
                                                        FirstName,
                                                        LastName 
                                                    FROM Patient 
                                                    WHERE PatientID=@PatientID", new { PatientID = patientID }).Single();
            }
        }

    }
}
