using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using MvcDataAccess.Caching;
using MvcIOC;
using MvcModel;

namespace MvcDataAccess.Patients
{
    public class GetPatientDataAccess : IDataHandler 
    {
        readonly IConnectionInformation conn;
        readonly IDataCache dataCache;

        public GetPatientDataAccess()
        {
            conn = KernelInjection.GetService<IConnectionInformation>();
            dataCache = KernelInjection.GetService<IDataCache>();
        }

        public Patient Execute(int patientID)
        {
            string key = Patient.GetCacheKey(patientID);

            if (dataCache.IsSet(key))
                return dataCache.Get<Patient>(key);

            using (var dbConnection = new SqlConnection(conn.ConnectString))
            {
                dbConnection.Open();
                var patient = dbConnection.Query<Patient>(@"SELECT 
                                                        PatientID, 
                                                        FirstName,
                                                        LastName 
                                                    FROM Patient 
                                                    WHERE PatientID=@PatientID", new { PatientID = patientID }).Single();

                dataCache.Set<Patient>(key, patient);
                
                return patient;
            }
        }
    }
}
