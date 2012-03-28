using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using MvcApplication2.Models;

namespace MvcApplication2.IoC
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

        private static void bindKernel()
        {
            kernel.Bind<IConnectionInformation>().To<ConnectionInformation>();
            kernel.Bind<IPatientDataAccess>().To<PatientDataAccess>();
        }
    }
}