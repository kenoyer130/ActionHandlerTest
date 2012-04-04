using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcActions.Patients;
using MvcModel;
using MvcActions;
using System.Reflection;
using MvcIOC;

namespace MvcWeb.ActionRepository
{
    // glues an actionhandler together
    public class HandlerRepository : IHandlerRepository     
    {
        public U Get<T, U>(dynamic parameters)
        {
            // get our handler
            var handler = KernelInjection.GetService<T>();
            if (handler == null)
                throw new ArgumentException("Handler did not resolve");

            // get our handler type
            Type handlerType = handler.GetType();

            // get the execute method
            MethodInfo executeMethod = handlerType.GetMethod("Execute");

            var actionRequestType = executeMethod.GetParameters()[0].ParameterType;

            var actionRequest = Activator.CreateInstance(actionRequestType);

            if (parameters != null)
                mapProperties(actionRequest, parameters, actionRequestType.GetProperties());

            // execute handler and return results
            return (U)executeMethod.Invoke(handler, new object[] { actionRequest });
        }

        private void mapProperties(object actionRequest, dynamic parameters, PropertyInfo[] properties)
        {
            // find the anonymous properties
            foreach (var param in parameters.GetType().GetProperties())
            {
                Boolean found = false;

                // find all properties of the request
                foreach (var prop in properties)
                {
                    var proptype = prop.GetType();
                    if (param.Name == prop.Name)
                    {
                        // map the property values across
                        if (param.GetType().ToString() != proptype.ToString())
                            throw new ArgumentException(string.Format("Parameter {0} was of type {1} when type {2} expected.", param.Name, param.GetType(), proptype));
                        
                        prop.SetValue(actionRequest, param.GetValue(parameters, null), null);
                        found = true;
                    }
                }

                if (!found)
                    throw new ArgumentException(string.Format("Parameter {0} was not found on request object.", param.Name));
            }
        }
    }
}
