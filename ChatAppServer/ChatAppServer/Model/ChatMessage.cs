namespace ChatAppServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Text.Json;

    [Table("ChatMessage")]
    public partial class ChatMessage
    {
        [Key]
        public Guid MessageId { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid? GroupId { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual ChatGroup ChatGroup { get; set; }

        public virtual ChatUser ChatUser { get; set; }

        public string ParseToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        public ChatMessage GetFromJson(string json)
        {
            return JsonSerializer.Deserialize<ChatMessage>(json);
        }
    }
}
