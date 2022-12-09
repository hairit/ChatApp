using ChatAppServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.DTO
{
    public class AddMember
    {
        public Guid GroupId { get; set; }
        public List<GroupUser> user { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public AddMember GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<AddMember>(json);
        }
    }
}
