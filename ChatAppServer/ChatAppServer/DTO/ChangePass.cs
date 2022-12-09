using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.DTO
{
    public class ChangePass
    {
        public string UserName { get; set; }
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public ChangePass GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<ChangePass>(json);
        }
    }
}
