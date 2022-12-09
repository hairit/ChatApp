using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.Model
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
