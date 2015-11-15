using System.Data.Entity;
using Destination = CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter05.Destination;
using Lodging = CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter05.Lodging;
using Person = CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter05.Person;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter05
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BreakAwayContext>(new MigrateDatabaseToLatestVersion<BreakAwayContext, MigrationsDataAnnotationsChapter05.Configuration>());

            base.OnModelCreating(modelBuilder);
        }
    }
}