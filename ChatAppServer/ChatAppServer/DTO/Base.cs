using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.Model
{
    public class Base
    {
        public string action { get; set; }
        public string model { get; set; }
        public string content {get; set;}

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
