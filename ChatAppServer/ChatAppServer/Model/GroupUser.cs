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
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public bool isApprove { get; set; }
        public virtual ChatUser User { get; set; }
        public virtual ChatGroup ChatGroup { get; set; }

        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public GroupUser GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<GroupUser>(json);
        }

    }
}
