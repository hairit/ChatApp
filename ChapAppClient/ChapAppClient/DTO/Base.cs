using System.Text.Json;

namespace ChatAppServer.DTO
{
    public class Base
    {
        public string action { get; set; }
        public string model { get; set; }
        public string content { get; set; }

        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public Base GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<Base>(json);
        }
    }
}