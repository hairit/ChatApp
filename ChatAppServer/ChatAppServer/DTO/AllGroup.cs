using ChatAppServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.DTO
{
    public class AllGroup
    {
        public List<ChatGroup> list { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public AllGroup GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<AllGroup>(json);
        }
    }
}
