using System;
using System.Linq;

namespace MvcDataAccess.Caching
{
    public interface IDataCache
    {
        T Get<T>(string key) where T : class;

        void Set<T>(string key, T data);

        bool IsSet(string key);

        void Invalidate(string key);
    }
}
