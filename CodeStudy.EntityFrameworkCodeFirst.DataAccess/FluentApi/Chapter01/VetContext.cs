using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeStudy.EntityFrameworkCodeFirst.Model.FluentApi.Chapter01;

namespace CodeStudy.EntityFrameworkCodeFirst.DataAccess.FluentApi.Chapter01
{
    public class VetContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<VetContext, MigrationsFluentApiChapter01.Configuration>());

            modelBuilder.Entity<AnimalType>().ToTable("Species");
            modelBuilder.Entity<AnimalType>().Property(a => a.TypeName).IsRequired().HasMaxLength(200);

            base.OnModelCreating(modelBuilder);
        }
    }
}
