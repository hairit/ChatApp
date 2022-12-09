using System.Text.Json;

namespace ChatAppServer.DTO
{
    public class GetUser
    {
        public string UserName { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public GetUser GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<GetUser>(json);
        }
    }
}