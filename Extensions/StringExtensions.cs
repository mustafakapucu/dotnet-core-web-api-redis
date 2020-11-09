using Newtonsoft.Json;

namespace simple_redis_api_on_docker.Extensions
{
    //TODO: Herhangi bir stringi belirtilen objeye çevirir.
    public static class StringExtension
    {
        public static T ToObject<T>(this string value) where T : class
        {
            return string.IsNullOrEmpty(value) ? null : JsonConvert.DeserializeObject<T>(value);
        }
    }
}