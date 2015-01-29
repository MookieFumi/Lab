using Newtonsoft.Json;

namespace lab.crosscutting
{
    public class JsonSerializer : IJsonSerializer
    {
        public string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.Indented);
        }
    }
}