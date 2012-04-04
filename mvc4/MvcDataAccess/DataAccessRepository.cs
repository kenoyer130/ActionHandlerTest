using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcIOC;
using System.Reflection;

namespace MvcDataAccess
{
    public class DataAccessRepository : MvcDataAccess.IDataAccessRepository
    {
        public void Execute<T>(dynamic parameters)
        {
            Execute<T, Object>(parameters);
        }

        public U Execute<T, U>(dynamic parameters)
        {
            // get our handler
            var handler = KernelInjection.GetService<T>();
            if (handler == null)
                throw new ArgumentException("DataAccess did not resolve");

            // get our handler type
            Type handlerType = handler.GetType();

            // get the execute method
            MethodInfo executeMethod = handlerType.GetMethod("Execute");
            if (executeMethod == null)
                throw new ArgumentException("Execute method was not found");

            var methodParameters = executeMethod.GetParameters();

            List<object> methodInvokeParams = new List<object>();

            if (parameters != null)
            {
                foreach (var methodParam in methodParameters)
                {
                    methodInvokeParams.Add(mapProperty(parameters, methodParam));
                }
            }

            // execute handler and return results
            return (U)executeMethod.Invoke(handler, methodInvokeParams.ToArray());
        }

        private object mapProperty(dynamic parameters, ParameterInfo methodProp)
        {
            // find the anonymous properties
            foreach (var param in parameters.GetType().GetProperties())
            {
                var proptype = methodProp.GetType();
                if (param.Name == methodProp.Name)
                {
                    // map the property values across
                    if (param.PropertyType != methodProp.ParameterType)
                        throw new ArgumentException(string.Format("Parameter {0} was of type {1} when type {2} expected.", param.Name, param.ParameterType, methodProp.ParameterType));

                    var newParam = Activator.CreateInstance(param.PropertyType);
                    newParam = param.GetValue(parameters, null);

                    return newParam;
                }
            }

            throw new ArgumentException(string.Format("Parameter {0} was not found on request object.", methodProp.Name));
        }
    }
}
