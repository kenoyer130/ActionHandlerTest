using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcActions
{
    public interface IActionResult
    {
        
    }

    public interface IActionSingleResult : IActionResult
    {
        int ID { get; set; }
    }
}
