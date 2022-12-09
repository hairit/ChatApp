using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
