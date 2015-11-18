using CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter03;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter03
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BreakAwayContext, MigrationsDataAnnotationsChapter03.Configuration>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}