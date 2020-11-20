namespace Medical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.RegisteredDevices");
        }
    }
}
