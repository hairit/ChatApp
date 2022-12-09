namespace ChatAppServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatGroup",
                c => new
                    {
                        GroupId = c.Guid(nullable: false),
                        GroupName = c.String(maxLength: 100),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        ChatUser_UserId = c.Guid(),
                        ChatUser_UserId1 = c.Guid(),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.ChatUser", t => t.ChatUser_UserId)
                .ForeignKey("dbo.ChatUser", t => t.ChatUser_UserId1)
                .Index(t => t.ChatUser_UserId)
                .Index(t => t.ChatUser_UserId1);
            
            CreateTable(
                "dbo.ChatMessage",
                c => new
                    {
                        MessageId = c.Guid(nullable: false),
                        CreatedBy = c.Guid(),
                        CreatedDate = c.DateTime(nullable: false),
                        GroupId = c.Guid(),
                        Content = c.String(nullable: false),
                        ChatUser_UserId = c.Guid(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.ChatGroup", t => t.GroupId)
                .ForeignKey("dbo.ChatUser", t => t.ChatUser_UserId)
                .Index(t => t.GroupId)
                .Index(t => t.ChatUser_UserId);
            
            CreateTable(
                "dbo.ChatUser",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        ChatGroup_GroupId = c.Guid(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ChatGroup", t => t.ChatGroup_GroupId)
                .Index(t => t.ChatGroup_GroupId);
            
            CreateTable(
                "dbo.GroupUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        GroupId = c.Guid(nullable: false),
                        isApprove = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChatGroup", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.ChatUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupUser", "UserId", "dbo.ChatUser");
            DropForeignKey("dbo.GroupUser", "GroupId", "dbo.ChatGroup");
            DropForeignKey("dbo.ChatUser", "ChatGroup_GroupId", "dbo.ChatGroup");
            DropForeignKey("dbo.ChatGroup", "ChatUser_UserId1", "dbo.ChatUser");
            DropForeignKey("dbo.ChatMessage", "ChatUser_UserId", "dbo.ChatUser");
            DropForeignKey("dbo.ChatGroup", "ChatUser_UserId", "dbo.ChatUser");
            DropForeignKey("dbo.ChatMessage", "GroupId", "dbo.ChatGroup");
            DropIndex("dbo.GroupUser", new[] { "GroupId" });
            DropIndex("dbo.GroupUser", new[] { "UserId" });
            DropIndex("dbo.ChatUser", new[] { "ChatGroup_GroupId" });
            DropIndex("dbo.ChatMessage", new[] { "ChatUser_UserId" });
            DropIndex("dbo.ChatMessage", new[] { "GroupId" });
            DropIndex("dbo.ChatGroup", new[] { "ChatUser_UserId1" });
            DropIndex("dbo.ChatGroup", new[] { "ChatUser_UserId" });
            DropTable("dbo.GroupUser");
            DropTable("dbo.ChatUser");
            DropTable("dbo.ChatMessage");
            DropTable("dbo.ChatGroup");
        }
    }
}
