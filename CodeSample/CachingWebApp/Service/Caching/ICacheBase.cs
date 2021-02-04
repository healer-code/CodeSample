using System;

namespace CachingWebApp.Service.Caching
{
    public interface ICacheBase
    {
        T Get<T>(string key);

        void Add<T>(string key, T cacheData);

        void Remove(string key);

        T GetOrCreate<T>(string key, TimeSpan timeExpiredCache, Func<T> cacheData);
    }
}