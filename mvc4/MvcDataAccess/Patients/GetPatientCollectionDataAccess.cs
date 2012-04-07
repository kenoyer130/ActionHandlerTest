using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MvcIOC;
using MvcModel;

namespace MvcDataAccess.Patients
{
    public class GetPatientCollectionDataAccess : IDataHandler 
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
