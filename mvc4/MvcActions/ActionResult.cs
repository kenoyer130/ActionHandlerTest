using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcActions
{
    public abstract class ActionResult : IActionResult
    {
        public bool HasError { get; set; }
        public string[] Errors { get; set; }    
    }
}