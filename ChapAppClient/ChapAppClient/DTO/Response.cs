 using System.Text.Json;

namespace ChatAppServer.DTO
{
    public class Response
    {
        public string action { get; set; }
        public string content { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public Response GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<Response>(json);
        }
    }
}