using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using simple_redis_api_on_docker.Extensions;
using StackExchange.Redis;

namespace simple_redis_api_on_docker.Services
{
     public class RedisCacheService : ICacheService
    {
        private readonly ConnectionMultiplexer _client;

        public RedisCacheService(IConfiguration configuration)
        {
            //TODO: Redisin bağlanacağı url appsettings.json "localhost:6379" olarak ayarlandı.
            var connectionString = configuration.GetSection("RedisConfiguration:ConnectionString")?.Value;

            ConfigurationOptions options = new ConfigurationOptions
            {
                EndPoints =
                {
                    connectionString //Redis'e bağlanılacak olan url.
                },
                AbortOnConnectFail = false,//Redise bağlanamadığı durumda 
                AsyncTimeout = 10000, //Redis'e async isteklerde 10 sn den geç yanıt verirse timeouta düşmesi için
                ConnectTimeout = 10000 //Redis'e normal isteklerde 10 sn den geç yanıt verirse timeouta düşmesi için
            };

            _client = ConnectionMultiplexer.Connect(options); // Redise bağlanmak için.            
        }

        public void Set(string key, string value)
        {
            _client.GetDatabase().StringSet(key, value);
        }

        public void Set<T>(string key, T value) where T : class
        {
            _client.GetDatabase().StringSet(key, value.ToJson());
        }

        public Task SetAsync(string key, object value)
        {
            return _client.GetDatabase().StringSetAsync(key, value.ToJson());
        }

        public void Set(string key, object value, TimeSpan expiration)
        {
            _client.GetDatabase().StringSet(key, value.ToJson(), expiration);
        }

        public Task SetAsync(string key, object value, TimeSpan expiration)
        {
            return _client.GetDatabase().StringSetAsync(key, value.ToJson(), expiration);
        }

        public T Get<T>(string key) where T : class
        {
            string value = _client.GetDatabase().StringGet(key);

            return value.ToObject<T>();
        }

        public string Get(string key)
        {
            return _client.GetDatabase().StringGet(key);
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            string value = await _client.GetDatabase().StringGetAsync(key);

            return value.ToObject<T>();
        }

        public void Remove(string key)
        {
            _client.GetDatabase().KeyDelete(key);
        }
    }
}