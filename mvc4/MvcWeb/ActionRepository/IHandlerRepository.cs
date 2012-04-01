using System;
namespace MvcWeb.ActionRepository
{
    public interface IHandlerRepository
    {
        U Get<T, U>(dynamic parameters);
    }
}
