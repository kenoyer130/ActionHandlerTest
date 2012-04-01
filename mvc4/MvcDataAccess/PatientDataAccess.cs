using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MvcModel;
using System.Diagnostics;

namespace MvcDataAccess
{
    public class PatientDataAccess : IPatientDataAccess
    {
        IConnectionInformation conn;

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


        public IEnumerable<Patient> GetPatientCollection()
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                return dbConnection.Query<Patient>(@"SELECT 
                                                        PatientID, 
                                                        FirstName,
                                                        LastName 
                                                    FROM Patient").ToList<Patient>();
            }
        }

        public int CreatePatient(Patient patient)
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                return (int)dbConnection.Query<decimal>(@"INSERT INTO PATIENT(FirstName,LastName)VALUES(@FirstName,@LastName) select SCOPE_IDENTITY()",
                    new { FirstName = patient.FirstName, LastName = patient.LastName }).First();              
            }
        }


        public void UpdatePatient(Patient patient)
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                dbConnection.Execute(@"UPDATE PATIENT SET FirstName=@FirstName, LastName=@LastName WHERE PatientID=@PatientID;",
                    new {PatientID = patient.PatientID, FirstName = patient.FirstName, LastName = patient.LastName });
            }                      
        }

        public void DeletePatient(int patientID)
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                dbConnection.Execute(@"Delete from Patient where PatientID=@PatientID;",
                    new { patientID });
            }
        }
    }
}