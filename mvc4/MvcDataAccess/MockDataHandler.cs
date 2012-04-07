using System;
using System.Linq;
using MvcModel;

namespace MvcDataAccess
{
    // used for unit testing
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
