using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MvcModel;
using System.Diagnostics;
using MvcIOC;

namespace MvcDataAccess.Patients
{
    public class GetPatientDataAccess 
    {
        IConnectionInformation conn;

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
