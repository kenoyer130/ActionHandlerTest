using System;
using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;

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
            return (T)Get().TryGet(typeof(T));
        }

        private static void bindKernel()
        {
            kernel.Bind(x => x
            .From("MvcWeb", "MvcDataAccess", "MvcActions")
            .SelectAllClasses()
            .BindAllInterfaces());
        }
    }
}