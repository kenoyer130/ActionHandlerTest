using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using MvcIOC;

namespace MvcDataAccess.Patients
{
    public class DeletePatientDataAccess : IDataHandler 
    {
        IConnectionInformation conn;

        public DeletePatientDataAccess()
        {
            conn = KernelInjection.GetService<IConnectionInformation>();
        }

        public void Execute(int patientID)
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
