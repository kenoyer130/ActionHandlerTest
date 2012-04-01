using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using MvcDataAccess;
using MvcWeb.ActionRepository;

namespace MvcIOC
{
    public static class KernelInjection
    {
        private static IKernel kernel;

        public static IKernel Get()
        {
            if (kernel != null)
                return kernel;

            kernel = new StandardKernel();

            bindKernel();

            return kernel;
        }

        public static T GetService<T>()
        {
            return (T)kernel.TryGet(typeof(T));
        }

        private static void bindKernel()
        {
            kernel.Bind<IConnectionInformation>().To<ConnectionInformation>();
            kernel.Bind<IPatientDataAccess>().To<PatientDataAccess>();
            kernel.Bind<IHandlerRepository>().To<HandlerRepository>(); 
        }
    }
}