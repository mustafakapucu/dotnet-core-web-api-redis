using Newtonsoft.Json;

namespace simple_redis_api_on_docker.Extensions
{
    //TODO: Herhangi bir objeyi json stringine çevirir.
    public static class ObjectExtension
    {
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}