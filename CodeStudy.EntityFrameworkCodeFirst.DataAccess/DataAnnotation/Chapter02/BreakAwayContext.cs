using CodeStudy.EntityFrameworkCodeFirst.DataAccess.MigrationsDataAnnotationsChapter02;
using CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter02;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter02
{
    public class BreakAwayContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BreakAwayContext>(new MigrateDatabaseToLatestVersion<BreakAwayContext, Configuration>());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}