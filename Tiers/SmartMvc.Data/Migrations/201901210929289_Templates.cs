namespace SmartMvc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Templates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        TempId = c.Int(nullable: false, identity: true),
                        TempCode = c.String(maxLength: 20),
                        TempTitle = c.String(nullable: false, maxLength: 150),
                        TempPath = c.String(maxLength: 100),
                        TempDescription = c.String(),
                        CategoryTypeId = c.Int(nullable: false),
                        TempIsDefualt = c.Boolean(nullable: false),
                        TempAddDate = c.DateTime(nullable: false),
                        TempModifyDate = c.DateTime(nullable: false),
                        TempUserId = c.Guid(nullable: false),
                        TempModifyUserId = c.Guid(),
                        TempPriority = c.Int(nullable: false),
                        TempIsDeleted = c.Boolean(nullable: false),
                        TempIsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TempId)
                .ForeignKey("dbo.CategoryTypes", t => t.CategoryTypeId)
                .Index(t => t.CategoryTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Templates", "CategoryTypeId", "dbo.CategoryTypes");
            DropIndex("dbo.Templates", new[] { "CategoryTypeId" });
            DropTable("dbo.Templates");
        }
    }
}
