using System;
using System.Runtime.Caching;

namespace ChennaiSarees.Infrastructure.Caching
{
    public interface ICacheStorage
    {
        void Remove(string key);

        void Store(string key, object data);

        void Store(string key, object data, CacheItemPolicy cacheItemPolicy);

        void Store(string key, object data, TimeSpan slidingExpiration);

        void Store(string key, object data, DateTime absoluteExpiration, TimeSpan slidingExpiration);

        T Retrieve<T>(string key);
    }
}