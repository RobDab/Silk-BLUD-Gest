namespace Silk_BLUD_Gest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DonorSinceNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Donors", "DonorSince", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Donors", "DonorSince", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
