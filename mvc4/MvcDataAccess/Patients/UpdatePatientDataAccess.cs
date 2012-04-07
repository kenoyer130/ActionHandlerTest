using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MvcDataAccess.Caching;
using MvcIOC;
using MvcModel;

namespace MvcDataAccess.Patients
{
    public class UpdatePatientDataAccess : IDataHandler 
    {
        readonly IConnectionInformation conn;
        readonly IDataCache dataCache;

        public UpdatePatientDataAccess()
        {
            conn = KernelInjection.GetService<IConnectionInformation>();
            dataCache = KernelInjection.GetService<IDataCache>();
        }

        public void Execute(Patient patient)
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                dbConnection.Execute(@"UPDATE PATIENT SET FirstName=@FirstName, LastName=@LastName WHERE PatientID=@PatientID;",
                    new { PatientID = patient.PatientID, FirstName = patient.FirstName, LastName = patient.LastName });
            }

            dataCache.Invalidate(patient.GetCacheKey());
        }
    }
}
