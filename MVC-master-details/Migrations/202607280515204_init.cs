namespace test111.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BorrowedItems",
                c => new
                    {
                        BorrowedItemId = c.Int(nullable: false, identity: true),
                        BookName = c.String(),
                        AuthorName = c.String(),
                        MemberId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowedItemId)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        MobileNo = c.String(),
                        MembershipFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IssueDate = c.DateTime(nullable: false),
                        IsStudent = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Members", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BorrowedItems", "MemberId", "dbo.Members");
            DropIndex("dbo.Members", new[] { "CategoryId" });
            DropIndex("dbo.BorrowedItems", new[] { "MemberId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Members");
            DropTable("dbo.BorrowedItems");
        }
    }
}
