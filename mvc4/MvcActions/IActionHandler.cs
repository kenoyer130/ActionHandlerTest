using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcActions
{
    public interface IActionHandler<T, U>
        where T : IActionRequest
        where U : IActionResult
    {
        U Execute(T actionRequest);
    }
}