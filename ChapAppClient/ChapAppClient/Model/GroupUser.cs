using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatAppServer.Model
{
    [Table("GroupUser")]
    public class GroupUser
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public Guid GroupId { get; set; }
        public bool isApprove { get; set; }
        public virtual ChatUser user { get; set; }
        public virtual ChatGroup ChatGroup { get; set; }

        public string ParseToJson(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
        public GroupUser GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<GroupUser>(json);
        }

    }
}
