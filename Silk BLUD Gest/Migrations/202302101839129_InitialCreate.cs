namespace Silk_BLUD_Gest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BottlesInFeedings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FeedingID = c.Int(nullable: false),
                        BottleID = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Feedings", t => t.FeedingID)
                .ForeignKey("dbo.Stock", t => t.BottleID)
                .Index(t => t.FeedingID)
                .Index(t => t.BottleID);
            
            CreateTable(
                "dbo.Feedings",
                c => new
                    {
                        FeedingID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(nullable: false),
                        AdministrationDate = c.DateTime(nullable: false, storeType: "date"),
                        MlDie = c.Int(nullable: false),
                        Consent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FeedingID)
                .ForeignKey("dbo.Patients", t => t.PatientID)
                .Index(t => t.PatientID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Lastname = c.String(nullable: false, maxLength: 30),
                        GestationalAge = c.Int(nullable: false),
                        BirthWeight = c.Double(nullable: false),
                        NutritionStart = c.DateTime(nullable: false, storeType: "date"),
                        NutritionEnd = c.DateTime(nullable: false, storeType: "date"),
                        MixedNutritionStart = c.DateTime(storeType: "date"),
                        WeightAtNutritionEnd = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        BottleID = c.String(nullable: false, maxLength: 30),
                        FreezingDate = c.DateTime(nullable: false, storeType: "date"),
                        DonorID = c.Int(nullable: false),
                        Identifier = c.String(maxLength: 1),
                        PasteurizationDate = c.DateTime(storeType: "date"),
                        Proteins = c.Double(),
                    })
                .PrimaryKey(t => t.BottleID)
                .ForeignKey("dbo.Donors", t => t.DonorID)
                .Index(t => t.DonorID);
            
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        DonorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Lastname = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false),
                        Contact = c.String(nullable: false, maxLength: 30),
                        Active = c.Boolean(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false, storeType: "date"),
                        GestationWeek = c.Int(nullable: false),
                        DonorSince = c.DateTime(storeType: "date"),
                        DonorTo = c.DateTime(storeType: "date"),
                        ClinicalNotes = c.String(),
                        BreastPumpProvided = c.DateTime(storeType: "date"),
                        BreastPumpTaken = c.DateTime(storeType: "date"),
                        TotalDonated = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DonorID);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        DonationID = c.Int(nullable: false, identity: true),
                        DonorID = c.Int(nullable: false),
                        FreezingDate = c.DateTime(nullable: false, storeType: "date"),
                        Quantity = c.Int(nullable: false),
                        BottleNum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DonationID)
                .ForeignKey("dbo.Donors", t => t.DonorID)
                .Index(t => t.DonorID);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        ExamsResultsID = c.Int(nullable: false, identity: true),
                        DonorID = c.Int(nullable: false),
                        ExamsDate = c.DateTime(nullable: false, storeType: "date"),
                        LMCulture = c.String(nullable: false, maxLength: 10),
                        HBV = c.Boolean(nullable: false),
                        HCV = c.Boolean(nullable: false),
                        HIV = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ExamsResultsID)
                .ForeignKey("dbo.Donors", t => t.DonorID)
                .Index(t => t.DonorID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        Role = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Stock", "DonorID", "dbo.Donors");
            DropForeignKey("dbo.Exams", "DonorID", "dbo.Donors");
            DropForeignKey("dbo.Donations", "DonorID", "dbo.Donors");
            DropForeignKey("dbo.BottlesInFeedings", "BottleID", "dbo.Stock");
            DropForeignKey("dbo.Feedings", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.BottlesInFeedings", "FeedingID", "dbo.Feedings");
            DropIndex("dbo.Users", new[] { "RoleID" });
            DropIndex("dbo.Exams", new[] { "DonorID" });
            DropIndex("dbo.Donations", new[] { "DonorID" });
            DropIndex("dbo.Stock", new[] { "DonorID" });
            DropIndex("dbo.Feedings", new[] { "PatientID" });
            DropIndex("dbo.BottlesInFeedings", new[] { "BottleID" });
            DropIndex("dbo.BottlesInFeedings", new[] { "FeedingID" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Exams");
            DropTable("dbo.Donations");
            DropTable("dbo.Donors");
            DropTable("dbo.Stock");
            DropTable("dbo.Patients");
            DropTable("dbo.Feedings");
            DropTable("dbo.BottlesInFeedings");
        }
    }
}
