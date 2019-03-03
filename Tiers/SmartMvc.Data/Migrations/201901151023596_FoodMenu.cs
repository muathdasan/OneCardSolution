namespace SmartMvc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodMenu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodMenus",
                c => new
                    {
                        FMenuId = c.Int(nullable: false, identity: true),
                        FMenuCode = c.String(maxLength: 20),
                        FMenuTitle = c.String(nullable: false, maxLength: 150),
                        FMenuDescription = c.String(),
                        FMenuPrice = c.Int(nullable: false),
                        FMenuAddDate = c.DateTime(nullable: false),
                        FMenuModifyDate = c.DateTime(nullable: false),
                        FMenuUserId = c.Guid(nullable: false),
                        FMenuModifyUserId = c.Guid(),
                        FMenuPriority = c.Int(nullable: false),
                        FMenuIsDeleted = c.Boolean(nullable: false),
                        FMenuIsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FMenuId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodMenus");
        }
    }
}
