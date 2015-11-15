namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsFluentApiChapter01
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAnimalTypeTypeNameMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Species", "TypeName", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Species", "TypeName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
