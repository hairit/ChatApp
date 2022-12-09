using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.Model
{
    public class response
    {
        public string action { get; set; }
        public string content { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public response GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<response>(json);
        }
    }
}
