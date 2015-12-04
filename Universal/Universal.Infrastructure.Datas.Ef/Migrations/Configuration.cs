using System.Data.Entity.Migrations;

namespace Universal.Infrastructure.Datas.Ef.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<UniversalUnitOfWork>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Migrations";
            ContextKey = "Universal.Infrastructure.Datas.Ef.UniversalUnitOfWork";
        }

        protected override void Seed(Universal.Infrastructure.Datas.Ef.UniversalUnitOfWork unitOfWork)
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