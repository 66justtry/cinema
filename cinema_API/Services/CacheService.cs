using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;

namespace cinema_API.Services
{
    public class CacheService : ICacheService
    {
        private IDatabase _db;
        public CacheService(IConnectionMultiplexer multiplexer)
        {
            _db = multiplexer.GetDatabase();
        }
        public T GetData<T>(string key)
        {
            var res = _db.StringGet(key);
            if (!string.IsNullOrEmpty(res))
            {
                return JsonConvert.DeserializeObject<T>(res);
            }
            return default;
        }

        public bool RemoveData(string key)
        {
            bool exists = _db.KeyExists(key);
            if (exists)
                return _db.KeyDelete(key);
            return false;
        }

        public bool SetData<T>(string key, T value)
        {
            return _db.StringSet(key, JsonConvert.SerializeObject(value), TimeSpan.FromSeconds(60));
        }
    }
}
