using CodeStudy.EntityFrameworkCodeFirst.Model.DataAnnotation.Chapter01;
using System.Data.Entity;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.DataAnnotation.Chapter01
{
    public class VetContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<VetContext>(new MigrateDatabaseToLatestVersion<VetContext, MigrationsDataAnnotationChapter01.Configuration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}