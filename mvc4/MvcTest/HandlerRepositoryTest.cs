using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcDataAccess;
using MvcIOC;
using MvcModel;

namespace MvcTest
{
    [TestClass]
    public class HandlerRepositoryTest
    {
        [TestMethod]
        public void ExecuteNoReturnType()
        {
            var handler = new HandlerRepository();
            var patient = handler.Execute<MockDataHandler, Patient>(new { ID = 1, firstName = "name", lastName = "lastName" });

            Assert.AreEqual(1, patient.PatientID);
            Assert.AreEqual("name", patient.FirstName);
            Assert.AreEqual("lastName", patient.LastName);
        }

        [TestMethod]
        public void ExecuteMetricTest()
        {
            Random rnd = new Random();

            int iterations = 10000;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < iterations; i++)
            {
                var handler = new HandlerRepository();                
                var patient = handler.Execute<MockDataHandler, Patient>(new { ID = rnd.Next(), firstName = "name", lastName = "lastName" });
            }

            stopwatch.Stop();

            Debug.WriteLine(string.Format("{0} iterations in {1}", iterations, stopwatch.ElapsedMilliseconds));
        }
    }
}

