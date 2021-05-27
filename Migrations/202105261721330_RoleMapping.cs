namespace RepositoryPattern.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleMapping : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.UserRoleMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoleMappings", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoleMappings", "RoleId", "dbo.Roles");
            DropIndex("dbo.UserRoleMappings", new[] { "RoleId" });
            DropIndex("dbo.UserRoleMappings", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRoleMappings");
            DropTable("dbo.Roles");
        }
    }
}
