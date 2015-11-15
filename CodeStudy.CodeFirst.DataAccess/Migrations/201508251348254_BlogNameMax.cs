namespace CodeStudy.CodeFirst.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogNameMax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "Name", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Name", c => c.String());
        }
    }
}
