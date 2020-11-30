namespace Medical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BatchClaimeds",
                c => new
                    {
                        date = c.DateTime(nullable: false),
                        batch_id = c.Int(nullable: false),
                        submittedEnv = c.Int(nullable: false),
                        collectedEnv = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => new { t.date, t.batch_id })
                .ForeignKey("dbo.Batches", t => t.batch_id, cascadeDelete: true)
                .Index(t => t.batch_id);
            
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        batch_id = c.Int(nullable: false, identity: true),
                        batch_date_from = c.DateTime(),
                        batch_date_to = c.DateTime(),
                    })
                .PrimaryKey(t => t.batch_id);
            
            CreateTable(
                "dbo.Claims",
                c => new
                    {
                        claim_id = c.Int(nullable: false, identity: true),
                        emp_id = c.String(),
                        first_name = c.String(),
                        last_name = c.String(),
                        number_of_claims = c.Int(nullable: false),
                        claim_date = c.DateTime(nullable: false),
                        batch_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.claim_id)
                .ForeignKey("dbo.Batches", t => t.batch_id, cascadeDelete: true)
                .Index(t => t.batch_id);
            
            CreateTable(
                "dbo.hrs",
                c => new
                    {
                        emp_id = c.Int(nullable: false, identity: true),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.emp_id);
            
            CreateTable(
                "dbo.RegisteredDevices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ipAddress = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Claims", "batch_id", "dbo.Batches");
            DropForeignKey("dbo.BatchClaimeds", "batch_id", "dbo.Batches");
            DropIndex("dbo.Claims", new[] { "batch_id" });
            DropIndex("dbo.BatchClaimeds", new[] { "batch_id" });
            DropTable("dbo.RegisteredDevices");
            DropTable("dbo.hrs");
            DropTable("dbo.Claims");
            DropTable("dbo.Batches");
            DropTable("dbo.BatchClaimeds");
        }
    }
}
