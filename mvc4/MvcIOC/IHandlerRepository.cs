using System;
namespace MvcIOC
{
    public interface IHandlerRepository
    {
        void Execute<T>(dynamic parameters);
        U Execute<T, U>(dynamic parameters);
        U Get<T, U>(dynamic parameters);
    }
}
