using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Ninject;

namespace MvcApplication2.Models
{
    public class PatientDataAccess : IPatientDataAccess
    {
        IConnectionInformation conn;

        [Inject]
        public PatientDataAccess(IConnectionInformation conn)
        {
            this.conn = conn;
        }

        public Patient GetPatient(int patientID)
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