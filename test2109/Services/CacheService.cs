using Microsoft.Extensions.Caching.Memory;


namespace test2109.Services;

public class CacheService 
{
    IMemoryCache _memoryCache;
    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
   

    /// <summary>
    /// Put a cache entry on server
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name">CacheKey name</param>
    /// <param name="entry">CacheKey value</param>
    /// <param name="unit">Time Unit 1 to 5 milli to Week </param>
    /// <param name="time">time delay</param>
    /// <example>SetCache(Key, value, 2, 1) 2 for choose seconds and 1 is number of seconds</example>
    public void SetCache<T>(string name, T entry, int unit = 1, int time = 0)
    {
        MemoryCacheEntryOptions cacheEntryOptions = new MemoryCacheEntryOptions();
        switch (unit)
        {

            case 1:
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromMilliseconds(time));
                break;

            case 2:
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromSeconds(time));
                break;

            case 3:
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromMinutes(time));
                break;

            case 4:
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromHours(time));
                break;

            case 5:
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromDays(time));
                break;

            default:
                cacheEntryOptions.SetSlidingExpiration(TimeSpan.FromMilliseconds(time));
                break;
        }

        _memoryCache.Set(name, entry, cacheEntryOptions);
    }

    //Put A cache entry on the server
    public T GetCache<T>(string name)
    {
        _memoryCache.TryGetValue(name, out T result);
        return result;
    }
}
