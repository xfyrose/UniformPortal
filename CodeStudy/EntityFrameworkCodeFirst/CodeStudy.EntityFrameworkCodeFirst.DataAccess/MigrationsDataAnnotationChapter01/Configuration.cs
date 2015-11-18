namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsDataAnnotationChapter01
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter01.VetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"MigrationsDataAnnotationChapter01";
            ContextKey = "CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter01.VetContext";
        }

        protected override void Seed(CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter01.VetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
