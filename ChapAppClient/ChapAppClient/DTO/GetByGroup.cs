using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.DTO
{
    public class GetByGroup
    {
        public Guid GroupID { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public GetByGroup GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<GetByGroup>(json);
        }
    }
}
