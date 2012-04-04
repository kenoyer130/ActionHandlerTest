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
    public class GetPatientCollectionDataAccess 
    {
        IConnectionInformation conn;

        public GetPatientCollectionDataAccess()
        {
            conn = KernelInjection.GetService<IConnectionInformation>();
        }

        public IEnumerable<Patient> Execute()
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
    }
}
