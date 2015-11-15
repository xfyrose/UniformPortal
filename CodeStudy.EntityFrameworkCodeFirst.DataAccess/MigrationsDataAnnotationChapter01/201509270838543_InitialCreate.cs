namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsDataAnnotationChapter01
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        FirstVisit = c.DateTime(nullable: false),
                        AnimalType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnimalTypes", t => t.AnimalType_Id)
                .Index(t => t.AnimalType_Id);
            
            CreateTable(
                "dbo.AnimalTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ReasonForVisit = c.String(),
                        OutCome = c.String(),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Patients", "AnimalType_Id", "dbo.AnimalTypes");
            DropIndex("dbo.Visits", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "AnimalType_Id" });
            DropTable("dbo.Visits");
            DropTable("dbo.AnimalTypes");
            DropTable("dbo.Patients");
        }
    }
}
