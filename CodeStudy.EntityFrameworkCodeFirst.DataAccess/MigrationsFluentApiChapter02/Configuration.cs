namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsFluentApiChapter02
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter02.BreakAwayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"MigrationsFluentApiChapter02";
            ContextKey = "CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter02.BreakAwayContext";
        }

        protected override void Seed(CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter02.BreakAwayContext context)
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
