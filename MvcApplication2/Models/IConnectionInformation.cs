using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication2.Models
{
    public interface IConnectionInformation
    {
        String ConnectString { get; }
    }
}
