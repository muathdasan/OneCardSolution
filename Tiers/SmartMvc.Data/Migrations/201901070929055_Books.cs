namespace SmartMvc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Books : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookCode = c.String(maxLength: 20),
                        BookTitle = c.String(nullable: false, maxLength: 150),
                        BookPrice = c.Int(),
                        BookStatus = c.Int(nullable: false),
                        BookAuthor = c.String(maxLength: 100),
                        BookYear = c.Int(),
                        BookQuantity = c.Int(),
                        BookAddDate = c.DateTime(nullable: false),
                        BookModifyDate = c.DateTime(nullable: false),
                        BookUserId = c.Guid(nullable: false),
                        BookPriority = c.Int(nullable: false),
                        BookIsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
