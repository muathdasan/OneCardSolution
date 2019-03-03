namespace SmartMvc.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Owners : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        OwnerId = c.Int(nullable: false, identity: true),
                        OwnerCode = c.String(maxLength: 20),
                        OwnerDescription = c.String(),
                        OwnerAddress = c.String(),
                        OwnerFirstName = c.String(nullable: false, maxLength: 50),
                        OwnerSecondName = c.String(maxLength: 50),
                        OwnerFamilyName = c.String(nullable: false, maxLength: 50),
                        OwnerFullNameEn = c.String(maxLength: 100),
                        OwnerEmail = c.String(maxLength: 100),
                        OwnerPhone = c.String(maxLength: 20),
                        OwnerMobile = c.String(maxLength: 20),
                        OwnerNationalNo = c.String(nullable: false, maxLength: 20),
                        OwnerGender = c.Int(nullable: false),
                        OwnerPlaceOfBirth = c.Int(),
                        OwnerDateOfBirth = c.DateTime(),
                        OwnerBloodType = c.Int(),
                        OwnerPassportNo = c.String(maxLength: 50),
                        OwnerPassportPlace = c.String(maxLength: 100),
                        OwnerPassportEndDate = c.DateTime(),
                        OwnerCollage = c.Int(),
                        OwnerNationality = c.Int(nullable: false),
                        OwnerStatus = c.Boolean(nullable: false),
                        CategoryTypeId = c.Int(nullable: false),
                        OwnerTemplateId = c.Int(nullable: false),
                        OwnerDocumentNo = c.String(maxLength: 50),
                        OwnerDocumentDate = c.DateTime(),
                        OwnerHafizaNo = c.String(maxLength: 50),
                        OwnerHafizaDate = c.DateTime(),
                        OwnerIqamaNo = c.String(maxLength: 50),
                        OwnerIqamaPlace = c.String(maxLength: 50),
                        OwnerIqamaStartDate = c.DateTime(),
                        OwnerIqamaEndDate = c.DateTime(),
                        OwnerImagePath = c.String(maxLength: 100),
                        OwnerImageContentType = c.String(maxLength: 25),
                        OwnerImageExtension = c.String(maxLength: 100),
                        OwnerImageLength = c.String(maxLength: 100),
                        OwnerAttachFile1 = c.String(maxLength: 150),
                        OwnerAttachFile2 = c.String(maxLength: 150),
                        OwnerAttachFile3 = c.String(maxLength: 150),
                        OwnerAddDate = c.DateTime(nullable: false),
                        OwnerModifyDate = c.DateTime(nullable: false),
                        OwnerUserId = c.Guid(nullable: false),
                        OwnerModifyUserId = c.Guid(),
                        OwnerIsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OwnerId)
                .ForeignKey("dbo.CategoryTypes", t => t.CategoryTypeId)
                .ForeignKey("dbo.Templates", t => t.OwnerTemplateId)
                .Index(t => t.CategoryTypeId)
                .Index(t => t.OwnerTemplateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Owners", "OwnerTemplateId", "dbo.Templates");
            DropForeignKey("dbo.Owners", "CategoryTypeId", "dbo.CategoryTypes");
            DropIndex("dbo.Owners", new[] { "OwnerTemplateId" });
            DropIndex("dbo.Owners", new[] { "CategoryTypeId" });
            DropTable("dbo.Owners");
        }
    }
}
