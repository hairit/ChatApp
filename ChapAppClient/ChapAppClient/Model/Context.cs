using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ChatAppServer.Model
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<ChatGroup> ChatGroups { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<ChatUser> ChatUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatGroup>()
                .HasMany(e => e.ChatUsers)
                .WithMany(e => e.ChatGroups1)
                .Map(m => m.ToTable("GroupUser").MapLeftKey("GroupId").MapRightKey("UserId"));

            modelBuilder.Entity<ChatUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ChatUser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<ChatUser>()
                .HasMany(e => e.ChatGroups)
                .WithRequired(e => e.ChatUser)
                .HasForeignKey(e => e.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChatUser>()
                .HasMany(e => e.ChatMessages)
                .WithOptional(e => e.ChatUser)
                .HasForeignKey(e => e.CreatedBy);
        }
    }
}
