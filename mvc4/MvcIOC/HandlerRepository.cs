using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Collections.Concurrent;

namespace MvcIOC
{
    public class HandlerRepository : IHandlerRepository     
    {
        private static readonly ConcurrentDictionary<string, MethodInfo> methodInfos = new ConcurrentDictionary<string, MethodInfo>();
        private static readonly ConcurrentDictionary<int, ParameterInfo[]> parameterInfo = new ConcurrentDictionary<int, ParameterInfo[]>();

        public void Execute<T>(dynamic parameters)
        {
            Execute<T, Object>(parameters);  
        }

        public U Execute<T, U>(dynamic parameters)
        {
            // get our handler
            T handler = getHandler<T>();

            // get the execute method
            var executeMethod = getExecuteMethod<T>(handler);

            var methodParameters = getMethodPropertyInfo(executeMethod.GetHashCode(), executeMethod);

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

        public U Get<T, U>(dynamic parameters)
        {
            // get our handler
            T handler = getHandler<T>();

            // get the execute method
            var executeMethod = getExecuteMethod<T>(handler);
           
            var actionRequestType = executeMethod.GetParameters()[0].ParameterType;

            var actionRequest = Activator.CreateInstance(actionRequestType);

            if (parameters != null)
                mapResultProperties(actionRequest, parameters, actionRequestType.GetProperties());

            // execute handler and return results
            return (U) executeMethod.Invoke(handler, new object[] { actionRequest });
        }

        private T getHandler<T>()
        {
            var handler =  KernelInjection.GetService<T>();
            if (handler == null)
                throw new ArgumentException("Handler did not resolve");
            return handler;
        }

        private MethodInfo getExecuteMethod<T>(T handler)
        {
            Type handlerType = handler.GetType();

            string key = handlerType.ToString();

            if (methodInfos.ContainsKey(key))
               return methodInfos[key];

            MethodInfo executeMethod = handlerType.GetMethod("Execute");
            if (executeMethod == null)
                throw new ArgumentException("Handler must have an Execute method.");

            methodInfos[key] = executeMethod;

            return executeMethod;
        }

        private ParameterInfo[] getMethodPropertyInfo(int key, MethodInfo methodInfo)
        {
            if (parameterInfo.ContainsKey(key))
                return parameterInfo[key];

            var info = methodInfo.GetParameters();

            parameterInfo[key] = info;

            return info;
        }

        private void mapResultProperties(object actionRequest, dynamic parameters, PropertyInfo[] properties)
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

                    var newParam = createInstance(param.PropertyType,parameters, param);
                    return newParam;
                }
            }

            throw new ArgumentException(string.Format("Parameter {0} was not found on request object.", methodProp.Name));
        }

        private object createInstance(Type type, dynamic parameters, PropertyInfo value)
        {
            if (type == typeof(string)) 
                return value.GetValue(parameters, null) as string;
            else if (type == typeof(int))
                return (int)value.GetValue(parameters, null);
            else{            
                var newParam = Activator.CreateInstance(type);
                newParam =  value.GetValue(parameters, null);
                return newParam;
            }            
        }
    }
}
