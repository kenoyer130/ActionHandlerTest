using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Actions
{
    public interface IActionHandler
    {
        IActionResult Execute();
    }
}