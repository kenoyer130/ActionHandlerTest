using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using MvcModel;
using MvcIOC;

namespace MvcDataAccess.Patients
{
    public class CreatePatientDataAccess {

        IConnectionInformation conn;

        public CreatePatientDataAccess(IConnectionInformation conn)
        {
            conn = KernelInjection.GetService<IConnectionInformation>();
        }

        public int Execute(Patient patient)
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                return (int)dbConnection.Query<decimal>(@"INSERT INTO PATIENT(FirstName,LastName)VALUES(@FirstName,@LastName); select SCOPE_IDENTITY();",
                    new { FirstName = patient.FirstName, LastName = patient.LastName }).First();
            }
        }
    }
}
