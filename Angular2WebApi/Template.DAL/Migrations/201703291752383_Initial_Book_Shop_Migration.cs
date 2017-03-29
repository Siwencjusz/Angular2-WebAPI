namespace Template.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Book_Shop_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Surname = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        ReleaseTime = c.DateTime(nullable: false),
                        Price = c.Double(nullable: false),
                        Author_Id = c.Int(nullable: false),
                        BookType_Id = c.Int(nullable: false),
                        PublishingHouse_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.BookTypes", t => t.BookType_Id, cascadeDelete: true)
                .ForeignKey("dbo.PublishingHouses", t => t.PublishingHouse_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.BookType_Id)
                .Index(t => t.PublishingHouse_Id);
            
            CreateTable(
                "dbo.BookTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PublishingHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublishingHouse_Id", "dbo.PublishingHouses");
            DropForeignKey("dbo.Books", "BookType_Id", "dbo.BookTypes");
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "PublishingHouse_Id" });
            DropIndex("dbo.Books", new[] { "BookType_Id" });
            DropIndex("dbo.Books", new[] { "Author_Id" });
            DropTable("dbo.PublishingHouses");
            DropTable("dbo.BookTypes");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
