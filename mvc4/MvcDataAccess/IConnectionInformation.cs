using System;
using System.Linq;

namespace MvcDataAccess
{
    public interface IConnectionInformation
    {
        String ConnectString { get; }
    }
}
