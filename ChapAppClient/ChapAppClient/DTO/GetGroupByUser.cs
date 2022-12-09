using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.DTO
{
    public class GetGroupByUser
    {
        public Guid userID { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public GetGroupByUser GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<GetGroupByUser>(json);
        }
    }
}
