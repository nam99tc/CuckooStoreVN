namespace CuckooStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCoupon : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Coupon", "Discount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Coupon", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
