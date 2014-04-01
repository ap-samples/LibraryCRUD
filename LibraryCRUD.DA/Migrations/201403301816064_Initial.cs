namespace LibraryCRUD.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        FullName = c.String(),
                        DateBorn = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        PublishDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Rarity = c.Int(nullable: false),
                        Publisher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publisher", t => t.Publisher_Id)
                .Index(t => t.Publisher_Id);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        FoundationDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookAuthor",
                c => new
                    {
                        Book_Id = c.Guid(nullable: false),
                        Author_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.Author_Id })
                .ForeignKey("dbo.Book", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Author", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "Publisher_Id", "dbo.Publisher");
            DropForeignKey("dbo.BookAuthor", "Author_Id", "dbo.Author");
            DropForeignKey("dbo.BookAuthor", "Book_Id", "dbo.Book");
            DropIndex("dbo.BookAuthor", new[] { "Author_Id" });
            DropIndex("dbo.BookAuthor", new[] { "Book_Id" });
            DropIndex("dbo.Book", new[] { "Publisher_Id" });
            DropTable("dbo.BookAuthor");
            DropTable("dbo.Publisher");
            DropTable("dbo.Book");
            DropTable("dbo.Author");
        }
    }
}
