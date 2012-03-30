using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Reflection;
using Ninject.Syntax;
using System.Web.Mvc;
using Ninject.Parameters;

namespace MvcIOC
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}