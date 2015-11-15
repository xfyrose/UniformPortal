namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsDataAnnotationChapter01
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnimalTypeTypeNameNotNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnimalTypes", "TypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AnimalTypes", "TypeName", c => c.String());
        }
    }
}
