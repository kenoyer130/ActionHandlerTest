using System;
using System.Runtime.Caching;

namespace MvcDataAccess.Caching
{
    public class DataCache : IDataCache
    {
        private static readonly ObjectCache cache = MemoryCache.Default;

        public T Get<T>(string key) where T : class
        {
            return cache[key] as T;
        }

        public void Set<T>(string key, T data)
        {
            if (IsSet(key))
                Invalidate(key);

            cache.Add(new CacheItem(key, data), getCacheItemPolicy());
        }

        public bool IsSet(string key)
        {
            return (cache[key] != null);
        }

        public void Invalidate(string key)
        {
            cache.Remove(key);
        }

        private CacheItemPolicy getCacheItemPolicy()
        {
            return new CacheItemPolicy()
              {
                  AbsoluteExpiration = DateTime.Now.AddMinutes(20)
              };
        }
    }
}