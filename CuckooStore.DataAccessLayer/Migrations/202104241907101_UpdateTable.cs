namespace CuckooStore.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BallotImportDetail");
            AddColumn("dbo.BallotImportDetail", "BallotImportDetailID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BallotImportDetail", "BallotImportDetailID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BallotImportDetail");
            DropColumn("dbo.BallotImportDetail", "BallotImportDetailID");
            AddPrimaryKey("dbo.BallotImportDetail", new[] { "ProductID", "BallotImportID" });
        }
    }
}
