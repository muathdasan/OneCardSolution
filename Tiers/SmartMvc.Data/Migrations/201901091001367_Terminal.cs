namespace SmartMvc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Terminal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Terminals",
                c => new
                    {
                        TermId = c.Int(nullable: false, identity: true),
                        TermCode = c.String(maxLength: 20),
                        TermTitle = c.String(nullable: false, maxLength: 150),
                        TermDescription = c.String(),
                        TermAddDate = c.DateTime(nullable: false),
                        TermModifyDate = c.DateTime(nullable: false),
                        TermUserId = c.Guid(nullable: false),
                        TermModifyUserId = c.Guid(),
                        TermPriority = c.Int(nullable: false),
                        TermIsDeleted = c.Boolean(nullable: false),
                        TermIsPublished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TermId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Terminals");
        }
    }
}
