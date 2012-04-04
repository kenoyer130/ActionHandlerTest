using System;
namespace MvcDataAccess
{
    public interface IDataAccessRepository
    {
        void Execute<T>(dynamic parameters);
        U Execute<T, U>(dynamic parameters);
    }
}
