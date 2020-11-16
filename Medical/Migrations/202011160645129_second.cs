namespace Medical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
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
                        collecttedEnv = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => new { t.date, t.batch_id })
                .ForeignKey("dbo.Batches", t => t.batch_id, cascadeDelete: true)
                .Index(t => t.batch_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BatchClaimeds", "batch_id", "dbo.Batches");
            DropIndex("dbo.BatchClaimeds", new[] { "batch_id" });
            DropTable("dbo.BatchClaimeds");
        }
    }
}
