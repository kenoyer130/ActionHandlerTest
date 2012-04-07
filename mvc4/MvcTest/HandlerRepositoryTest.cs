using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcDataAccess;
using MvcIOC;
using MvcModel;
using System.Collections.Generic;

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
            var handler = new HandlerRepository();

            Random rnd = new Random();

            int iterations = 10000;
            int maxRuns = 10;

            Stopwatch stopwatch = new Stopwatch();

            long[] runTime = new long[maxRuns];

            for (int run = 0; run < maxRuns; run++)
            {
                stopwatch.Reset();
                stopwatch.Start();
               
                for (int i = 0; i < iterations; i++)
                {                    
                    var patient = handler.Execute<MockDataHandler, Patient>(new { ID = rnd.Next(), firstName = "name", lastName = "lastName" });
                }

                stopwatch.Stop();

                runTime[run] = stopwatch.ElapsedMilliseconds;

                Debug.WriteLine(string.Format("Run {0} : {1} iterations in {2}", run, iterations, stopwatch.ElapsedMilliseconds));
            }

            IEnumerable<long> intSequence = runTime.Cast<long>();

            Debug.WriteLine(string.Format("Average time per run {0}", intSequence.Average()));
        }
    }
}

