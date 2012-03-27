using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcApplication2.Actions
{
    public interface IActionResult
    {
        bool HasError { get; set; }
        string[] Errors { get; set; }
    }
}
