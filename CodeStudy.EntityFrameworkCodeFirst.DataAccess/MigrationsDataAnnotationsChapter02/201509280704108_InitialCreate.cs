namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsDataAnnotationsChapter02
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Description = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.DestinationId);
            
            CreateTable(
                "dbo.Lodgings",
                c => new
                    {
                        LodgingId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Owner = c.String(),
                        IsResort = c.Boolean(nullable: false),
                        Destination_DestinationId = c.Int(),
                    })
                .PrimaryKey(t => t.LodgingId)
                .ForeignKey("dbo.Destinations", t => t.Destination_DestinationId)
                .Index(t => t.Destination_DestinationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lodgings", "Destination_DestinationId", "dbo.Destinations");
            DropIndex("dbo.Lodgings", new[] { "Destination_DestinationId" });
            DropTable("dbo.Lodgings");
            DropTable("dbo.Destinations");
        }
    }
}
