using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcDataAccess
{
    public interface IConnectionInformation
    {
        String ConnectString { get; }
    }
}
