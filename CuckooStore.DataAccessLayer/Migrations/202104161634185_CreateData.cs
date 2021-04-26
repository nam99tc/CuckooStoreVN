namespace CuckooStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BallotImportDetail",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        BallotImportID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.BallotImportID })
                .ForeignKey("dbo.BallotImport", t => t.BallotImportID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.BallotImportID);
            
            CreateTable(
                "dbo.BallotImport",
                c => new
                    {
                        BallotImportID = c.Int(nullable: false, identity: true),
                        NguoiNhan = c.String(nullable: false, maxLength: 200),
                        FromAdd = c.String(nullable: false, maxLength: 200),
                        Kho = c.String(maxLength: 200),
                        NgayNhap = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BallotImportID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 200),
                        Image = c.String(maxLength: 100),
                        BaoHanh = c.Int(nullable: false),
                        MauSac = c.String(nullable: false, maxLength: 30),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 2000),
                        Quantity = c.Int(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categoty", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categoty",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 2000),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        PassWord = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 200),
                        Phone = c.String(nullable: false, maxLength: 30),
                        Role = c.Int(nullable: false),
                        StatusUser = c.Int(nullable: false),
                        Image = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        ToName = c.String(maxLength: 200),
                        ToAddr = c.String(maxLength: 200),
                        ToPhone = c.String(maxLength: 30),
                        UserID = c.Int(),
                        Code = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Coupon", t => t.Code)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.Code);
            
            CreateTable(
                "dbo.Coupon",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.OrderID })
                .ForeignKey("dbo.Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 50),
                        Content = c.String(nullable: false, maxLength: 2000),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Order", "UserID", "dbo.User");
            DropForeignKey("dbo.OrderDetail", "OrderID", "dbo.Order");
            DropForeignKey("dbo.OrderDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.Order", "Code", "dbo.Coupon");
            DropForeignKey("dbo.Comment", "UserID", "dbo.User");
            DropForeignKey("dbo.Product", "CategoryID", "dbo.Categoty");
            DropForeignKey("dbo.BallotImportDetail", "ProductID", "dbo.Product");
            DropForeignKey("dbo.BallotImportDetail", "BallotImportID", "dbo.BallotImport");
            DropIndex("dbo.OrderDetail", new[] { "OrderID" });
            DropIndex("dbo.OrderDetail", new[] { "ProductID" });
            DropIndex("dbo.Order", new[] { "Code" });
            DropIndex("dbo.Order", new[] { "UserID" });
            DropIndex("dbo.Comment", new[] { "UserID" });
            DropIndex("dbo.Comment", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "CategoryID" });
            DropIndex("dbo.BallotImportDetail", new[] { "BallotImportID" });
            DropIndex("dbo.BallotImportDetail", new[] { "ProductID" });
            DropTable("dbo.Contact");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Coupon");
            DropTable("dbo.Order");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
            DropTable("dbo.Categoty");
            DropTable("dbo.Product");
            DropTable("dbo.BallotImport");
            DropTable("dbo.BallotImportDetail");
        }
    }
}
