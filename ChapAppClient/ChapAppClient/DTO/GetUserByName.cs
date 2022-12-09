using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.DTO
{
    public class GetUserByName
    {
        public string Name { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public GetUserByName GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<GetUserByName>(json);
        }
    }
}