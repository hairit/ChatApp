namespace ChatAppServer.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Text.Json;

    [Table("ChatGroup")]
    public partial class ChatGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatGroup()
        {
            ChatMessages = new HashSet<ChatMessage>();
            ChatUsers = new HashSet<ChatUser>();
        }

        [Key]
        public Guid GroupId { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ChatUser ChatUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatUser> ChatUsers { get; set; }

        public string ParseToJson(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
        public ChatGroup GetFromJson (string json)
        {
            return JsonSerializer.Deserialize<ChatGroup>(json);
        }
    }
}
