using System.Text.Json;

namespace ChatAppServer.DTO
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public Login GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<Login>(json);
        }
    }
}