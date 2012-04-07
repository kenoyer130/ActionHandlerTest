using System;
using System.Linq;
using MvcDataAccess;
using MvcModel;

namespace MvcTest
{
    public class MockDataHandler : IDataHandler
    {
        public Patient Execute(int ID, string firstName, string lastName)
        {
            return new Patient()
            {
                PatientID = ID,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
