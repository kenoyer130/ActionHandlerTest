using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MvcDataAccess.Caching;
using MvcIOC;
using MvcModel;

namespace MvcDataAccess.Patients
{
    public class DeletePatientDataAccess : IDataHandler 
    {
        IConnectionInformation conn;
        readonly IDataCache dataCache;

        public DeletePatientDataAccess()
        {
            conn = KernelInjection.GetService<IConnectionInformation>();
            dataCache = KernelInjection.GetService<IDataCache>();
        }

        public void Execute(int patientID)
        {
            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                dbConnection.Execute(@"Delete from Patient where PatientID=@PatientID;",
                    new { patientID });
            }

            dataCache.Invalidate(Patient.GetCacheKey(patientID));
        }
    }
}
