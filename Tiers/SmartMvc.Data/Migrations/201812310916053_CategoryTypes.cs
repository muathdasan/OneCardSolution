namespace SmartMvc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryTypes",
                c => new
                    {
                        CtId = c.Int(nullable: false, identity: true),
                        CtCode = c.String(maxLength: 20),
                        CtTitle = c.String(nullable: false, maxLength: 100),
                        CtDescription = c.String(),
                        CtAddDate = c.DateTime(nullable: false),
                        CtModifyDate = c.DateTime(nullable: false),
                        CtUserId = c.Guid(nullable: false),
                        CtPriority = c.Int(nullable: false),
                        CtIsDeleted = c.Boolean(nullable: false),
                        CtIsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CtId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategoryTypes");
        }
    }
}
